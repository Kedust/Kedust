const config = {
    api: {
        domain: process.env.VUE_APP_KEDUST_API_DOMAIN,
        table: {
            getByCode: "/Table/Code/{tableCode}",
            getByDescription: "/Table/Description/{tableDescription}"
        },
        menu:{
            getById: "/Menu/{id}"
        },
        order:{
            post : "/Order"
        },
        settings:{
            getByKey : "/Setting/Key/{key}"
        }
    }
};

export default config;