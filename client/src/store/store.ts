import { IUser } from "../models/IUser";
import { makeAutoObservable } from 'mobx'
import AuthService from "../service/UserServer";
import SettingService from "../service/SettingService";

export default class Store {
    user = {} as IUser;
    isAuth = false;
    redirectCallback: Function | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    setAuth(bool: boolean) {
        this.isAuth = bool;
    }

    setUser(user: IUser) {
        this.user = user;
    }

    setRedirectCallback(callback: Function) {
        this.redirectCallback = callback;
    }

    async login(email: string, password: string) {
        try {
            const response = await AuthService.login(email, password);
            console.log(response); // Delete this
            localStorage.setItem('token', response.data.result.accessToken);
            this.setAuth(true);
            this.setUser(response.data.result.user);
            if (this.redirectCallback) {
                this.redirectCallback('/');
            }
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
            if (this.redirectCallback) {
                this.redirectCallback('/');
            }
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

    async ChangeImg(imageUri: any) {
        try {
            const formData = new FormData();
            formData.append('image', imageUri);
            const response = await SettingService.ChangeImg(formData);
            this.setUser(response.data.result.user);
        } catch (error) {
            console.log(error)
        }
    }

    async ChangePassword(password: string) {
        try {
            const response = await SettingService.ChangePassword(password);
            this.setUser(response.data.result.user);
        } catch (error) {
            console.log(error)
        }
    }

    async ChangeName(username: string) {
        try {
            const response = await SettingService.ChangeName(username);
            this.setUser(response.data.result.user);
        } catch (error) {
            console.log(error)
        }
    }
}