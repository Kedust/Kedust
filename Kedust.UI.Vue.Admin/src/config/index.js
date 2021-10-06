const config = {
    api: {
        domain: "https://api.kedust.be",
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
        }
    }
};

export default config;
