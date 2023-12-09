import { IUser } from "../models/IUser";
import { makeAutoObservable } from 'mobx'
import AuthService from "../service/UserServer";
import { redirect } from "react-router-dom";

export default class Store {

    user = {} as IUser;
    isAuth = false;

    constructor() {
        makeAutoObservable(this);
    }

    setAuth(bool: boolean) {
        this.isAuth = bool;
    }

    setUser(user: IUser) {
        this.user = user;
    }

    async login(email: string, password: string) {
        try {
            const response = await AuthService.login(email, password);
            console.log(response); // Delete this
            localStorage.setItem('token', response.data.result.accessToken);
            this.setAuth(true);
            this.setUser(response.data.result.user);
            redirect("/");
        } catch (error) {
            console.log(error);
        }
    }

    async registration(username: string, email: string, password: string) {
        try {
            const response = await AuthService.registration(username, email, password);
            console.log(response); // Delete this
            localStorage.setItem('token', response.data.result.accessToken);
            this.setAuth(true);
            this.setUser(response.data.result.user);
            redirect("/");
        } catch (error) {
            console.log(error);
        }
    }

    async logout() {
        try {
            const response = await AuthService.logout();
            localStorage.removeItem('token');
            this.setAuth(false);
            this.setUser({} as IUser);
        } catch (error) {
            console.log(error);
        }
    }

    async checkAuth() {
        try {
            const response = await AuthService.refresh();

            localStorage.setItem('token', response.data.result.accessToken);
            this.setAuth(true);
            this.setUser(response.data.result.user);
        } catch (error) {
            console.log(error)
        }
    }
}