import { useEffect } from 'react';
import { useLocation } from 'react-router-dom';

function PageTitles() {
	const { pathname } = useLocation();

	useEffect(() => {
		let title = "NoteTakingApp";

		switch (pathname.toLocaleLowerCase().toLowerCase()) {
			case "/":
				title = "Login | NoteTakingApp";
				break;
			case "/note":
				title = "Notes | NoteTakingApp";
				break;
			case "/register":
				title = "Register | NoteTakingApp";
				break;
			case "/trash":
				title = "Trash | NoteTakingApp";
				break;
			case "/favorites":
				title = "Favorites | NoteTakingApp";
				break;
			case "/passwordchange":
				title = "Change Password | NoteTakingApp";
				break;
			default:
				title = "Not Found";
				break;
		}

		document.title = title;
	}, [pathname]);

	return null;
}

export default PageTitles;