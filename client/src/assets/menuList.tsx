import { ReactElement } from "react";
import { MdHome } from "react-icons/md";
import { MdAccountCircle } from "react-icons/md";
import { MdLocalFireDepartment } from "react-icons/md";

interface IListItem {
    path: string,
    name: string,
    icon: ReactElement
}

interface MenuList {
    listItem: IListItem[]
}

const menuList: MenuList = {
    listItem: [
        {
            path: '/',
            name: 'Home',
            icon: <MdHome />
        },
        {
            path: '/posts/search/Popular',
            name: 'Popular',
            icon: <MdLocalFireDepartment />
        }
    ]
};

export const menuAuthList: MenuList = {
    listItem: [
        {
            path: '/account',
            name: 'Account',
            icon: <MdAccountCircle />
        }
    ]
};

export default menuList;
