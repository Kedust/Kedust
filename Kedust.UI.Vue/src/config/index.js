const config = {
    api: {
        domain: "https://api.kedust.be",
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