import { ITopic } from "../ITopic";
import { IUser } from "../IUser";

export interface PostsResponse {
    result: {
        posts: {
            post: {
                id: string;
                title: string;
                description: string;
                topics: ITopic[];
                author: IUser;
                imageUri: string;
                dateCreated: string;
            }[]
        }
    }
}