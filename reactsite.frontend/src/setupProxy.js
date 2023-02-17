const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/user",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'http://localhost:5160',
        secure: false
    });

    app.use(appProxy);
};
