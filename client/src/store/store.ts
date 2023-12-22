import { IUser } from "../models/IUser";
import { IPost } from '../models/IPost'
import { makeAutoObservable } from 'mobx'
import AuthService from "../service/UserServer";
import SettingService from "../service/SettingService";
import PostService from "../service/PostsService";

export default class Store {
    user = {} as IUser;
    posts = [] as IPost[]
    isAuth = false;
    loading = false;
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

    setPost(posts: IPost[]) {
        this.posts = posts;
    }

    setLoading(loading: boolean) {
        this.loading = loading
    }

    setRedirectCallback(callback: Function) {
        this.redirectCallback = callback;
    }

    async login(email: string, password: string) {
        try {
            const response = await AuthService.login(email, password);
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

    async CreatePost(title: string, description: string, topics: number[], imageUri: any) {
        try {
            const responsePost = await PostService.CreatePost(title, description, topics)
            const formData = new FormData();
            formData.append('image', imageUri);
            const responsePostImg = await PostService.CreatePostImage(responsePost.data.result.post.id, formData)
            this.setPost([...this.posts, responsePostImg.data.result.post]);
        } catch (error) {
            console.log(error)
        }
    }

    async GetPosts() {
        try {
            this.setLoading(this.loading = true)
            const response = await PostService.GetPosts()
            this.setPost(response.data.result.posts);
            await this.setLoading(this.loading = false)
        } catch (error) {
            console.log(error)
        }
    }

    async GetSearchPosts(id: string | undefined, type: string) {
        try {
            this.setLoading(this.loading = true)
            const response = await PostService.SearchCategoryPosts(id, type)
            this.setPost(response.data.result.posts)
            await this.setLoading(this.loading = false)
        } catch (error) {
            console.log(error)
        }
    }
}