import React, { createContext } from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import Store from './store/store.ts';
import './assets/styles/reset.css'

interface State {
  store: Store,
}

const store = new Store();

export const Context = createContext<State>({
  store,
})

ReactDOM.createRoot(document.getElementById('root')!).render(
    <Context.Provider value={{ store }}>
      <App />
    </Context.Provider>,
)
