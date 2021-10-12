const config = {
    api: {
        domain: process.env.VUE_APP_KEDUST_API_DOMAIN,
        table: {
            checkCode: "/Table/Check/{tableCode}"
        },
        menu:{
            getByTableCode: "/Menu/Table/{tableCode}"
        },
        order:{
            post : "/Order"
        }
    }
};

export default config;