import '../App.css'

import { Link, useNavigate } from 'react-router-dom'
import { FiUser, FiShield } from "react-icons/fi";

function LoginPage() {
	return (
		<div className="container">
			<h1>User Login</h1>
			<div className="login-info">
				<div className="login-info-wrapper">
					<div className="login-info-field">
						<FiUser size="1.3em"/>
						<input type="text" id="username" placeholder="Username"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="password" placeholder="Password"/>
					</div>
					<div>
						<Link to="/note">
							<button className="login-btn">Login</button>
						</Link>
					</div>
				</div>
			</div>
		</div>
	);
}

export default LoginPage;