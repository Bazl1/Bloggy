import { ITopic } from "./ITopic";
import { IUser } from "./IUser";

export interface IPost {
    result: {
        post: {
            id: string;
            title: string;
            description: string;
            topics: ITopic[];
            author: IUser;
            imageUri: string;
            dateCreated: string;
        }
    }
}