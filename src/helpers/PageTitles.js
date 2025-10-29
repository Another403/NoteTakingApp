import { useEffect } from 'react';
import { useLocation } from 'react-router-dom';

function PageTitles() {
	const { pathname } = useLocation();

	useEffect(() => {
		let title = "NoteTakingApp";

		switch (pathname) {
			case "/":
				title = "Login | NoteTakingApp";
				break;
			case "/note":
				title = "Notes | NoteTakingApp";
				break;
			case "/register":
				title = "Register | NoteTakingApp";
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