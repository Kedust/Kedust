const config = {
    api: {
        domain: process.env.VUE_APP_KEDUST_API_DOMAIN,
        menu: {
            getAll: "/Menu",
            get: "/Menu/{id}",
            delete: "/Menu/{id}",
            update: "/Menu",
            post: "/Menu"
        },
        table: {
            getAll: "/Table",
            post: "/Table",
            get: "/Table/{id}",
            delete: "/Table/{id}"
        },
        setting:{
            setSetting: "/Setting/Key/{key}/{value}"
        }
    }
};

export default config;
