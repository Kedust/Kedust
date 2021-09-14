module.exports = {
    chainWebpack: config => {
        config
            .plugin('html')
            .tap(args => {
                args[0].title = "Kédust";
                args[0].description = "Geef je tafelcode in en bestel meteen je drankjes, snacks, gerechten...";
                return args;
            })
    }
}