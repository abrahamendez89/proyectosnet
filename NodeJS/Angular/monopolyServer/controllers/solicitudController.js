
module.exports = function (ws) {
    var module = {};
    
    module.guardaSolicitud = function (req, res) {
         console.log(req.body);
            console.log("Guardando solicitud.");
            ws('message', 'Enviando mensaje desde un web socket...');
            res.json({"uno":"dos"});
    };

    module.checadorFail = function (req, res) {
         console.log(req.body);
            console.log("Pidiendo huella de empleado");
            //ws('message', 'Enviando mensaje desde un web socket...');
            res.json({"error":"","status":"0","template64":"asdasdasdasd"});
            //yo
            //res.json({"error":"","status":"0","template64":"KwD3APYACgAQAJ0ACAExAAQArwCMAHIACgDIAL4AgAAXANAA7AAqACgAlgAnAeoABwB9AIYAawBSAI8AuwBLAAYAhQD1APcACAClABwB7QAGAHUASAHVAAoAtAC0AGgADADKAOYAtQBDALcADQHsAAoA3wDlAAEAFwCkAC4BKQAIAHkAmgBQAA8AkwAOAeoABACBAC8AYQELADgAPQAlAAsA7ADGAEwBDwCfAKIAYwAKALQAMQHmAAcAjABWAFcBEAA/AGoAQgAJAIcAjwBrABcAzQDUAJYAOwBMAEwA0gAKAPoAyABGAQ8ATwBxAOAADADGAHIAOQECAIYAeACHABcAPACRAPcABACuAEgB2wAJAF4AhAA9ABEAUgD3AOwABwA2AAIB6gAIAFMAEAHlAAkAXgA4AdkABACmAFUAhQAFABgApgAEAQkAjgA3AJYACwBRACYAygAKABcAAAD/////////////////////////////////YmVpbnUECQ4RExQVFhb//////////1VgY2hrdAQKDxMWFxgZGSH/////////U1teYmZ0Bg0TFxgaGxwcIv////////9VWVteY3ADDRUZGhwdHBwg/////////1RYV1lfbgENFxwdHx8dHB0h////////UFRTVlxpdg8bICEhISAfHyD//////0NKTk9RVmBzGCEkJCMkIyEhIf//////QEVJS01QUUEqKScmJSUkIiIj//////8/REdJSklHPzUwLSonJSMhISL//////z5DRkdHRkM/OjczLSgkISAgIv//////QkZJSEdGREI/OzgzKSEbGxz///////9ESEtKSUhHRkJAPTkrHBUWGP///////0tMTkxMTEtJRkRCQTURDQ8R////////UE9QT1BQUE5LSkhKVXMDBgr///////9UUlRSVAAAAAB4"});
            //chaval
            //res.json({"error":"","status":"0","template64":"EACDAK0ADgAKAEoA0AAwAAsAKAAgAT0ABwBxAIIACwAKAEcAowAfAAkAMABHAVIACQCQAOQAZQEWAEAAPgFaAAcAfgBAAGUBBABVAF0ADgAMAGQABgHtAAoAXgCwAMsACgCDACsAUQEFAJMAMgFxAB0AlAAqAXwAOgC9ADQAogAHABcAAAD///////////////////////////////////93AwYKDA8NC///////////////////dHcCBQgLDg4NDAkHBS7//////////2pydgIEBgkLDQ0MDBMnNzr/////////a3F1dwIEBgkLDA0PEys3Of///////1lpb3J0dwIFCAkKCgwSKTP/////////XmptbnF1AgUHCAkJCg8mMf////////9haWprbnJ3AwYICQkKDyn//////////2FpaWlscHQCBQgKCwwRKv//////////X2VnZ2lscncFCAsNDxIn//////////9dYWNjZWlxdgUJDQ8RFCP//////////1teYGBiZ292BQsPEhQXIv//////////WFtcXF9jbXUGDhIWFxoh//////////9WV1dXW19pdAcRFhkZGyD//////////1RVVFNVWWNxCBQZGxscIP//////////UVJRT1FVXm0JFhscHB0g//////////9NTkxLS1BXZwwZHR8dHyH/////////SkpKSEdHSlBUGRwgHx0dIP////////9IR0dFREJDRD0qISEfHBz//////////0hHRkJAPz49NiwjIR0bG////////////0dGQj47OjYwKCIdGhgY/////////////0pDOzc0KycgGxgWExH/////////////////////FxQRDw4L////////////dAEAAACQAAAAJQEAAHwAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB4"});
    };

    return module;
};