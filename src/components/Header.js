import React from 'react';

function Header({ handleToggleDarkMode, handleLogout }) {
	return(
		<div className="header">
			<h1>Notes</h1>
			<div className="header-buttons">
				<button className="save" onClick={handleLogout}>Logout</button>
				<button className="save">Trash</button>
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