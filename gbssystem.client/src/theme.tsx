import {createTheme} from "@mantine/core";
//import {cabinet, satoshi} from "./fonts"

export const theme = createTheme({
    components: {
        Button: {
            defaultProps: {
                loaderProps: {type: "bars", size: 'xs'},
            }
        }
    },
    focusRing: "auto",
    fontSmoothing: true,
    white: "#feffff",
    black: "#1b1a1a",
    defaultGradient: {from: 'orange.7', to: 'red.9', deg: 110},
    primaryColor: "orange",
    primaryShade: 7,
    defaultRadius: "sm",
    respectReducedMotion: true,
    shadows: {
        md: '1px 1px 3px rgba(0, 0, 0, .10)',
        lg: '1px 1px 3px rgba(0, 0, 0, .10)',
        xl: '5px 5px 3px rgba(0, 0, 0, .15)',
    },
    headings: {
        fontFamily: '"Press Start 2P", system-ui',
        fontWeight: "400",
        textWrap: "balance",
    },
    fontFamily: '"Urbanist", system-ui',
});
