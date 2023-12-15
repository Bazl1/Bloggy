import $api from "../assets/utils/axios/index";
import { AxiosResponse } from "axios";
import { CategoryResponse } from "../models/response/CategoryResponse"
import { IPost } from "../models/IPost";

export default class PostService {
    static async fetchCategory(): Promise<AxiosResponse<CategoryResponse[]>> {
        return $api.get<CategoryResponse[]>('/topics')
    }

    static async CreatePost(title: string, description: string, topics: number[]): Promise<AxiosResponse<IPost>> {
        return $api.post<IPost>('/posts', { title, description, topics })
    }

    static async CreatePostImage(id: string, imageUri: any): Promise<AxiosResponse<IPost>> {
        return $api.post<IPost>(`/posts/${id}/image`, imageUri)
    }
}
