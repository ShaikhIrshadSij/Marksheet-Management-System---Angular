import { RouteInfo } from './sidebar.metadata';

//Sidebar menu Routes and data
export const ROUTES: RouteInfo[] = [

    {
        path: '', title: 'Dashboard', icon: 'ft-home', class: 'has-sub', badge: '2', badgeClass: 'badge badge-pill badge-danger float-right mr-1 mt-1', isExternalLink: false, 
        submenu: [
            { path: '/dashboard', title: 'Dashboard', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
            { path: '/dashboard/marksheet', title: 'Marksheet', icon: '', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
        ]
    },
    { path: '/dashboard/marksheet-data', title: 'Color Palette', icon: 'ft-droplet', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] }
];
