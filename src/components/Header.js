import React from 'react';
import { useNavigate, useLocation } from 'react-router-dom';

function Header({ handleToggleDarkMode, handleLogout, pageTitle }) {
	const navigate = useNavigate();
	const location = useLocation();

	return(
		<div className="header">
			<h1>{pageTitle}</h1>
			<div className="header-buttons">
				<button className="save" onClick={handleLogout}>Logout</button>
				<button className="save" onClick={() => navigate('/note')}>Notes</button>
				<button className="save" onClick={() => navigate('/favorites')}>Favorites</button>
				<button className="save" onClick={() => navigate('/trash')}>Trash</button>
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