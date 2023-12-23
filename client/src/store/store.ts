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
    end = false;
    active= false;
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

    setEndPosts(end: boolean) {
        this.end = end
    }

    setLoading(loading: boolean) {
        this.loading = loading
    }

    setActiveSidebar(active: boolean){
        this.active = active
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


    CheckLastReq(posts: any[]) {
        if (posts.length == 0 || posts.length % 3 !== 0) {
            this.setEndPosts(true)
        } else {
            this.setEndPosts(false)
        }
    }

    async GetPosts(number: number) {
        try {
            this.setLoading(this.loading = true)
            const response = await PostService.GetPosts(number)
            const newPosts = [...this.posts, ...response.data.result.posts]
            this.setPost(newPosts);
            this.setLoading(this.loading = false)
            this.CheckLastReq(response.data.result.posts)
        } catch (error) {
            console.log(error)
        }
    }

    async GetSearchPosts(id: string | undefined, type: string, number: number) {
        try {
            this.setLoading(this.loading = true)
            const response = await PostService.SearchCategoryPosts(id, type, number)
            const newPosts = [...this.posts, ...response.data.result.posts]
            this.setPost(newPosts);
            this.setLoading(this.loading = false)
            this.CheckLastReq(response.data.result.posts)
        } catch (error) {
            console.log(error)
        }
    }

    async ClearPosts() {
        try {
            this.setPost([])
        } catch (error) {
            console.log(error)
        }
    }
}