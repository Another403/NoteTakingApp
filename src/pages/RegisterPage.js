import '../App.css'

import { Link, useNavigate } from 'react-router-dom'
import { FiUser, FiShield, FiRepeat, FiUserCheck } from "react-icons/fi";
import { useState } from 'react';
import { api } from '../api';

function RegisterPage() {
	const [email, setEmail] = useState('');
	const [password1, setPassword1] = useState('');
	const [password2, setPassword2] = useState('');
	const [fullName, setFullName] = useState('');

	const navigate = useNavigate();

	const handleRegister = async () => {
		if (password1 !== password2) {
			alert('Password mismatch');
			return;
		}

		try {
			const res = await api.post('/signup', {
				email: email,
				fullName: fullName,
				password: password1,				
			});

			navigate('/');
		} catch (error) {
			alert('registration error');
		}
	}

	return (
		<div className="container">
			<h1>User Register</h1>
			<div className="login-info">
				<div className="login-info-wrapper">
					<div className="login-info-field">
						<FiUser size="1.3em"/>
						<input type="text" id="email" onChange={(event) => setEmail(event.target.value)} placeholder="Email"/>
					</div>
					<div className="login-info-field">
						<FiUserCheck size="1.3em"/>
						<input type="text" id="fullName" onChange={(event) => setFullName(event.target.value)} placeholder="Full name"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="password1" onChange={(event) => setPassword1(event.target.value)} placeholder="Password"/>
					</div>
                    <div className="login-info-field">
						<FiRepeat size="1.3em"/>
						<input type="text" id="password2" onChange={(event) => setPassword2(event.target.value)} placeholder="Re-enter password"/>
					</div>
					<div>
						<button className="login-btn" onClick={handleRegister}>Register</button>
					</div>
				</div>
			</div>
		</div>
	);
}

export default RegisterPage;