import { ReactElement } from "react";
import { MdHome } from "react-icons/md";

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
        }
    ]
};

export default menuList;
