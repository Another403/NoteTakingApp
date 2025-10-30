import './App.css';
import NotesList from './components/NotesList';
import Search from './components/Search';
import Header from './components/Header';
import axios from 'axios';

import React, { useState, useEffect } from 'react';
import { nanoid } from 'nanoid';

import { BrowserRouter, Routes, Route } from 'react-router-dom';

import NoteTakingPage from './pages/NoteTakingPage.js';
import LoginPage from './pages/LoginPage.js';
import RegisterPage from './pages/RegisterPage.js';
import TrashPage from './pages/TrashPage.js';
import FavoritesPage from './pages/FavoritesPage.js';

import PageTitles from './helpers/PageTitles.js';

function App() {
	return (
		<div className="App">
			<BrowserRouter>
				<PageTitles/>
				<Routes>
					<Route path='/' element={<LoginPage />}/>
					<Route path='/note' element={<NoteTakingPage />}/>
					<Route path='/register' element={<RegisterPage />}/>
					<Route path='/trash' element={<TrashPage/>}/>
					<Route path='/favorites' element={<FavoritesPage/>}/>
				</Routes>
			</BrowserRouter>
		</div>
	);
}

export default App;
