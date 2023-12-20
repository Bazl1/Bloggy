export interface CategoryResponse {
    result: {
        topics: {
            id: number;
            name: string;
        }[];
    };
}
