const config = {
    api: {
        domain: "https://api.kedust.be",
        menu: {
            getAll: "/Menu/GetAll",
            get: "/Menu",
            delete: "/Menu"
        },
        choice:{
            getByMenu: "/Choice/GetByMenu",
            saveByMenu: "/Choice/SaveByMenu"
        }
    }
};

export default config;
