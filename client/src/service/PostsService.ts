import $api from "../assets/utils/axios/index";
import { AxiosResponse } from "axios";
import { CategoryResponse } from "../models/response/CategoryResponse"

export default class SettingService {
    static async fetchCategory(): Promise<AxiosResponse<CategoryResponse[]>> {
        return $api.get<CategoryResponse[]>('/topics')
    }
}

