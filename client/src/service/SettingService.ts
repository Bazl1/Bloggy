import $api from "../assets/utils/axios/index";
import { AxiosResponse } from "axios";
import { AuthResponse } from "../models/response/AuthResponse";

export default class SettingService {
    static async ChangeImg(imageUri: any): Promise<AxiosResponse<AuthResponse>> {
        return $api.post<AuthResponse>('/accounts/my/image', { imageUri })
    }
}

