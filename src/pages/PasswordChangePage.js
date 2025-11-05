import '../App.css'

import axios from 'axios';

import { Link, useNavigate } from 'react-router-dom'
import { FiUser, FiShield } from "react-icons/fi";
import { useState } from 'react';
import { api } from '../api';

function PasswordChangePage() {
	const [oldPassword, setOldPassword] = useState('');
	const [newPassword1, setNewPassword1] = useState('');
	const [newPassword2, setNewPassword2] = useState('');

	const navigate = useNavigate();

	const handlePasswordChange = async () => {
		try {
			const res = await api.put('/changePassword', {
				oldPassword: oldPassword,
				newPassword1: newPassword1,
				newPassword2: newPassword2
			});

			alert('Password changed!');
			navigate('/note');
		} catch (err) {
			alert('Could not update password');
		}
	}

	return (
		<div className="container">
			<h1>Change Password</h1>
			<div className="login-info">
				<div className="login-info-wrapper">
					<div className="login-info-field">
						<FiUser size="1.3em"/>
						<input type="text" id="old-password" onChange={(event) => setOldPassword(event.target.value)} placeholder="Old Password"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="new-password1" onChange={(event) => setNewPassword1(event.target.value)} placeholder="New Password"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="new-password2" onChange={(event) => setNewPassword2(event.target.value)} placeholder="Confirm New Password"/>
					</div>
					<div>
						<button className="login-btn" onClick={handlePasswordChange}>Confirm</button>
					</div>
					<div>
						<button	className='login-btn' onClick = {() => navigate('/note')}>Cancel</button>
					</div>
				</div>
			</div>
		</div>
	);
}

export default PasswordChangePage;