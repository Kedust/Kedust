const config = {
    api: {
        domain: "https://localhost:5001",
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