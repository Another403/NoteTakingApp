import axios from 'axios';

export const api = axios.create({
	baseURL: 'https://uon1158tmh.execute-api.ap-southeast-2.amazonaws.com/dev/api'
	//baseURL: "https://localhost:7008/api"
});

let refreshing = false;
api.interceptors.response.use(
	(response) => response,
	async (error) => {
		if (error.response?.status === 401 && !refreshing) {
			refreshing = true;
			try {
				const refreshToken = localStorage.getItem("refreshToken");
				const res = await axios.post("https://uon1158tmh.execute-api.ap-southeast-2.amazonaws.com/dev/api/refreshToken", {refreshToken});
				localStorage.setItem('token', res.data.token);
				refreshing = false;

				error.config.headers.Authorization = `Bearer ${res.data.token}`;
				return api.request(error.config);
			} catch (err) {
				refreshing = false;
				localStorage.clear();
				window.location.href = "/";
			}
		}
		throw error;
	}
);

api.interceptors.request.use((config) => {
		const token = localStorage.getItem("token");
		if (token) {
			config.headers.Authorization = `Bearer ${token}`;
		}
		return config;
	}
);