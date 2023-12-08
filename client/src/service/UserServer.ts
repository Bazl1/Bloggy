import $api from "../assets/utils/axios/index";
import { AxiosResponse } from "axios";
import { AuthResponse } from "../models/response/AuthResponse";

export default class AuthService {
    static async login(email: string, password: string): Promise<AxiosResponse<AuthResponse>> {
        return $api.post<AuthResponse>('/login', { email, password })
    }

    static async registration(username: string, email: string, password: string): Promise<AxiosResponse<AuthResponse>> {
        return $api.post<AuthResponse>("/register", { username, email, password })
    }

    static async logout(): Promise<void> {
        return $api.post('/logout')
    }

    static async refresh(): Promise<AxiosResponse<AuthResponse>> {
        return $api.post("/refresh")
    }
}

