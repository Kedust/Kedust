const config = {
    api: {
        domain: process.env.VUE_APP_KEDUST_API_DOMAIN,
        table: {
            getByCode: "/Table/Code/{tableCode}"
        },
        menu:{
            getById: "/Menu/{id}"
        },
        order:{
            post : "/Order"
        }
    }
};

export default config;