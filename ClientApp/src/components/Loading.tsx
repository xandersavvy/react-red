const loadingStyle = {
    container : {
        display:"flex",
        justifyContent:"center",
        alignItems:"center",
        width:"100vw",
        height:"100vh"
    },
}

const Loading = () => {
    return (
        <div style={loadingStyle.container}>
            <h1>Enjoy this loading screen, BRB.</h1>
        </div>
    )
}

export default Loading;