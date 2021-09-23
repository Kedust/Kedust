const config = {
    api: {
        domain: "https://api.kedust.be",
        table: {
            checkCode: "/Table/CheckCode"
        },
        choice:{
            getByTableCode: "/Choice/GetByTableCode"
        },
        order:{
            post : "/Order"
        }
    }
};

export default config;