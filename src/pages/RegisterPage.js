import '../App.css'

import { Link, useNavigate } from 'react-router-dom'
import { FiUser, FiShield, FiRepeat } from "react-icons/fi";

function RegisterPage() {
	return (
		<div className="container">
			<h1>User Register</h1>
			<div className="login-info">
				<div className="login-info-wrapper">
					<div className="login-info-field">
						<FiUser size="1.3em"/>
						<input type="text" id="username" placeholder="Username"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="password1" placeholder="Password"/>
					</div>
                    <div className="login-info-field">
						<FiRepeat size="1.3em"/>
						<input type="text" id="password2" placeholder="Re-enter password"/>
					</div>
					<div>
						<Link to="/note">
							<button className="login-btn">Register</button>
						</Link>
					</div>
				</div>
			</div>
		</div>
	);
}

export default RegisterPage;