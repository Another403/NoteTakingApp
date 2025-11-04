import '../App.css'

import axios from 'axios';

import { Link, useNavigate } from 'react-router-dom'
import { FiUser, FiShield } from "react-icons/fi";
import { useState } from 'react';
import { api } from '../api';

function PasswordChangePage() {
	const navigate = useNavigate();

	return (
		<div className="container">
			<h1>Change Password</h1>
			<div className="login-info">
				<div className="login-info-wrapper">
					<div className="login-info-field">
						<FiUser size="1.3em"/>
						<input type="text" id="old-password" placeholder="Old Password"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="new-password1" placeholder="New Password"/>
					</div>
					<div className="login-info-field">
						<FiShield size="1.3em"/>
						<input type="text" id="new-password2" placeholder="Confirm New Password"/>
					</div>
					<div>
						<button className="login-btn">Confirm</button>
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