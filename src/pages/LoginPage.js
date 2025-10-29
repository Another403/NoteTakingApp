import '../App.css'

import axios from 'axios';

import { Link, useNavigate } from 'react-router-dom'
import { FiUser, FiShield } from "react-icons/fi";
import { useState } from 'react';
import { api } from '../api';

function LoginPage() {
	const [email, setEmail] = useState('');
	const [password, setPassword] = useState('');

	const navigate = useNavigate();

	const handleLogin = async () => {
		try {
			const res = await api.post('/signin', {
				email: email,
				password: password
			});
			localStorage.setItem('token', res.data.token);
			localStorage.setItem('refreshToken', res.data.refreshToken);
			
			navigate('/note');
		} catch (err) {
			alert("login failed");
		}
	}

	return (
		<div className="container">
			<h1>User Login</h1>
			<div className="login-info">
				<div className="login-info-wrapper">
					<div className="login-info-field">
						<FiUser size="1.3em"/>
						<input type="text" id="email" onChange={(event) => setEmail(event.target.value)} placeholder="Email"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="password" onChange={(event) => setPassword(event.target.value)} placeholder="Password"/>
					</div>
					<div>
							<button className="login-btn" onClick={handleLogin}>Login</button>
					</div>
					<div>
						<a href='/register'>Register as new user</a>
					</div>
				</div>
			</div>
		</div>
	);
}

export default LoginPage;