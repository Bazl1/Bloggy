import $api from "../assets/utils/axios/index";
import { AxiosResponse } from "axios";
import { CategoryResponse } from "../models/response/CategoryResponse"
import { IPost } from "../models/IPost";
import { PostsResponse } from "../models/response/PostsResponse";

export default class PostService {
    static async fetchCategory(): Promise<AxiosResponse<CategoryResponse[]>> {
        return $api.get<CategoryResponse[]>('/topics')
    }

    static async GetPosts(number: number = 0): Promise<AxiosResponse<PostsResponse[]>> {
        return $api.get<PostsResponse[]>(`/posts/?page=${number}`)
    }

    static async GetSinglePosts(postId: string): Promise<AxiosResponse<PostsResponse[]>> {
        return $api.get<PostsResponse[]>(`/posts/${postId}`)
    }

    static async CreatePost(title: string, description: string, topics: number[]): Promise<AxiosResponse<IPost>> {
        return $api.post<IPost>('/posts', { title, description, topics })
    }

    static async CreatePostImage(id: string, imageUri: any): Promise<AxiosResponse<IPost>> {
        return $api.post<IPost>(`/posts/${id}/image`, imageUri)
    }

    static async SearchCategoryPosts(id: string | undefined, type: string, number: number): Promise<AxiosResponse<PostsResponse[]>> {
        return $api.get<PostsResponse[]>(`/posts/?${type}=${id}&page=${number}`)

    }
}

