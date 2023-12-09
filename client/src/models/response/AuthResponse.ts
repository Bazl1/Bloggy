import { IUser } from "../IUser";

export interface AuthResponse {
    result: {
        accessToken: string;
        refreshToken: string;
        user: IUser;
    };
}