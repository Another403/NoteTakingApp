import React from 'react';
import { useNavigate, useLocation } from 'react-router-dom';

function Header({ handleToggleDarkMode, handleLogout, pageTitle }) {
	const navigate = useNavigate();
	const location = useLocation();

	const isTrashPage = location.pathname.toLowerCase() === '/trash';

	const handleTogglePage = () => {
		if (isTrashPage) {
			navigate('/note');
		} else {
			navigate('/trash');
		}
	}

	return(
		<div className="header">
			<h1>{pageTitle}</h1>
			<div className="header-buttons">
				<button className="save" onClick={handleLogout}>Logout</button>
				<button className="save" onClick={handleTogglePage}>{isTrashPage ? "Note" : "Trash"}</button>
				<button 
					className="save"
					onClick = {() => handleToggleDarkMode(
							(isDarkMode) => !isDarkMode
						)
					}
				>Toggle Mode</button>
			</div>
		</div>
	);
}

export default Header;