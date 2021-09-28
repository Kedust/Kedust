const config = {
    api: {
        domain: "https://localhost:5001",
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
