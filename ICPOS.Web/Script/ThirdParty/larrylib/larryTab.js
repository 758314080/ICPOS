layui.define(["jquery", "larryElem", "layer", "common"],
    function (e) {
        var t = layui.$,
            i = layui.larryElem,
            r = parent.layer === undefined ? layui.layer : parent.layer,
            a = layui.common;
        module_name = "larryTab";
        var n = "larrymenu";
        var l = 0;
        var o = function () {
            this.config = {
                top_menu: undefined,
                data: undefined,
                url: undefined,
                type: "GET",
                cached: false,
                spreadOne: false,
                topFilter: "TopMenu",
                left_menu: undefined,
                leftFilter: "LarrySide",
                larry_elem: undefined,
                tabFilter: "larryTab",
                maxTab: 50,
                tabSession: false,
                closed: false,
                contextMenu: false,
                autoRefresh: false
            }
        };
        o.prototype.set = function (e) {
            var i = this;
            t.extend(true, i.config, e);
            return i
        };
        var c = {};
        var f = new Array;
        o.prototype.menuSet = function (e) {
            var i = this;
            if (!e.hasOwnProperty("data") && !e.hasOwnProperty("url")) {
                a.larryCmsError("没有传入数据源:data 或 url参数，菜单项无法正常初始化！", a.larryCore.errorTit)
            }
            var r = ["top_menu", "left_menu", "data", "url", "type", "cached", "spreadOne", "topFilter", "leftFilter"];
            var n = h(e, r);
            t.extend(i.config, e);
            return i
        };
        o.prototype.tabSet = function (e) {
            var i = this;
            var r = ["larry_elem", "maxTab", "tabSession", "closed", "contextMenu", "autoRefresh"];
            var a = h(e, r);
            t.extend(i.config, a);
            return i
        };
        o.prototype.init = function () {
            var e = this;
            if (localStorage.getItem("fullscreen_info") || localStorage.getItem("tabSessions")) {
                var i = JSON.parse(localStorage.getItem("fullscreen_info"));
                var r = false;
                if (localStorage.getItem("themeName")) {
                    var a = localStorage.getItem("themeName");
                    t("#themeName option[value='" + a + "']").attr("selected", "selected")
                }
                if (i) {
                    t("#checkboxfull").attr("checked", "checked")
                }
                if (r) {
                    t("#checkboxtabSession").attr("checked", "checked");
                    e.config.tabSession = r
                } else {
                    e.config.tabSession = r;
                    sessionStorage.removeItem("tabMenu");
                    sessionStorage.removeItem("currentTabMenu")
                }
            } else if (e.config.tabSession) {
                t("#checkboxtabSession").attr("checked", "checked")
            }
            if (localStorage.getItem("autoRefresh")) {
                var n = JSON.parse(localStorage.getItem("autoRefresh"));
                if (n) {
                    t("#autoRefresh").attr("checked", "checked");
                    e.config.autoRefresh = n
                } else {
                    e.config.autoRefresh = n
                }
            } else if (e.config.autoRefresh) {
                t("#autoRefresh").attr("checked", "checked")
            }
            if (e.config.tabSession) {
                e.session(function (i) {
                    if (i.getItem("tabMenu")) {
                        var r = JSON.parse(i.getItem("tabMenu"));
                        t.each(r,
                            function (t, i) {
                                e.recoveryTab(i)
                            });
                        var a = JSON.parse(i.getItem("currentTabMenu"));
                        if (a) {
                            e.changeTab(a.id)
                        } else {
                            taht.changeTab(r[0].id)
                        }
                        l = r.length
                    } else {
                        var n = t("#larry_tab_title li").eq(0);
                        if (n.length) {
                            var o = JSON.parse(i.getItem("tabMenu")) || [];
                            var c = {
                                icon: n.children("i").data("icon"),
                                title: n.find("em").text() == undefined ? n.find("em").text() : "后台首页",
                                href: t("#larry_tab_content iframe").eq(0).attr("src"),
                                id: n.attr("lay-id"),
                                closed: false
                            };
                            o.push(c);
                            i.setItem("tabMenu", JSON.stringify(o));
                            i.setItem("currentTabMenu", JSON.stringify(c))
                        }
                    }
                })
            }
            t("#larry_tab").on("click", "#larry_tab_title li",
                function () {
                    e.changeTab(t(this).attr("lay-id"))
                });
            t("#larry_tab").on("click", "#larry_tab_title li i.layui-tab-close",
                function () {
                    if (e.config.closed) {
                        e.deleteTab(t(this).parent("li").attr("lay-id"));
                        e.tabMove(1, 1)
                    }
                });
            t(window).on("resize",
                function () {
                    t("#larry_admin_out").width(t(window).width()).height(t(window).height());
                    t("#larry_body").width(t("#larry_admin_out").width() - t("#larry_left").width() - 2);
                    t("#larry_body").height(t("#larry_admin_out").height() - 108);
                    t("#larry_tab").width(t("#larry_body").width()).height(t("#larry_body").height());
                    t("#larry_tab_content").width(t("#larry_tab").width()).height(t("#larry_tab").height() - t("#larry_title_box").height() - t("#larry_footer").innerHeight() + 5);
                    t("#larry_tab_content").find("iframe").each(function () {
                        t(this).height(t("#larry_tab_content").height());
                        t(this).width(t("#larry_tab_content").width())
                    })
                }).resize();
            t("#menuSwitch").on("click",
                function () {
                    t("#larry_admin_out").toggleClass("hideLeftNav")
                })
        };
        o.prototype.menu = function () {
            var e = this;
            var i = e.config;
            if (i.data === undefined && i.url === undefined) {
                a.larryCmsError("菜单加载失败", a.larryCore.errorDataTit)
            }
            if (i.data !== undefined && typeof i.data === "object") {
                e.larryCompleteMenu(i.data);
                e.init()
            } else {
                t.ajax({
                    type: i.type,
                    url: i.url,
                    async: false,
                    dataType: "json",
                    success: function (t, i, r) {
                        e.larryCompleteMenu(t)
                    },
                    error: function (e, t, i) {
                        a.larryCmsError(i, a.larryCore.errorDataTit)
                    },
                    complete: function () {
                        e.init()
                    }
                })
            }
            return e
        };
        o.prototype.larryCompleteMenu = function (e) {
            var t = this;
            var r = t.config;
            var a = d(r.left_menu, "left_menu");
            if (a !== "error") {
                var n = d(r.top_menu, "top_menu");
                if (n !== "undefined") {
                    var l = s(e, "on");
                    window.localStorage.setItem("larry_menu", JSON.stringify(l));
                    LeftMenuElem = l.left;
                    n.html(l.top);
                    a.html(l.left[0]);
                    i.init();
                    t.config.top_menu = n;
                    t.config.left_menu = a
                } else {
                    var l = s(e, "off");
                    window.localStorage.setItem("larry_menu", JSON.stringify(l));
                    LeftMenuElem = l;
                    a.html(l);
                    i.init();
                    _that.config.left_menu = a
                }
            }
        };
        o.prototype.on = function (e, r, a) {
            var n = this;
            var l = n.config;
            var o = u(e);
            var c = r != undefined ? r : "0";
            if (o.eventName === "click" && o.filter === l.topFilter) {
                l.left_menu.html(LeftMenuElem[r]);
                l.left_menu.attr("data-group", r);
                i.init()
            }
            if (o.eventName === "click" && o.filter === l.leftFilter) {
                if (l.left_menu.attr("lay-filter") !== undefined) {
                    l.left_menu.find("li").each(function () {
                        var e = t(this);
                        if (e.find("dl").length > 0) {
                            var i = e.find("dd").each(function () {
                                t(this).on("click",
                                    function () {
                                        var e = t(this).children("a");
                                        var i = e.data("url");
                                        var r = e.children("i:first").data("icon");
                                        var n = e.children("cite").text();
                                        var l = {
                                            elem: e,
                                            field: {
                                                href: i,
                                                icon: r,
                                                title: n,
                                                group: c
                                            }
                                        };
                                        a(l)
                                    })
                            })
                        } else {
                            e.on("click",
                                function () {
                                    var t = e.children("a");
                                    var i = t.data("url");
                                    var r = t.children("i:first").data("icon");
                                    var n = t.children("cite").text();
                                    var l = {
                                        elem: t,
                                        field: {
                                            href: i,
                                            icon: r,
                                            title: n,
                                            group: c
                                        }
                                    };
                                    a(l)
                                })
                        }
                    })
                }
            }
            return n
        };
        o.prototype.cleanCached = function () {
            layui.data(n, null);
            localStorage.clear();
            sessionStorage.clear();
            y()
        };
        o.prototype.tabInit = function () {
            var e = this;
            var t = e.config;
            $container = d(t.larry_elem, "larry_elem");
            t.larry_elem = $container;
            c.titleBox = $container.children("ul.layui-tab-title");
            c.contentBox = $container.children("div.layui-tab-content");
            c.tabFilter = $container.attr("lay-filter");
            c.tabCtrlBox = $container.find("#buttonRCtrl");
            return e
        };
        o.prototype.exists = function (e) {
            var i = -1;
            var r = c.titleBox === undefined ? this.tabInit() : this;
            c.titleBox.find("li").each(function (r, a) {
                var n = t(this).children("em");
                if (n.text() === e) {
                    i = r
                }
            });
            return i
        };
        o.prototype.getTabId = function (e) {
            var i = -1;
            var r = c.titleBox === undefined ? this.tabInit() : this;
            c.titleBox.find("li").each(function (r, a) {
                var n = t(this).children("em");
                if (n.text() === e) {
                    i = t(this).attr("lay-id")
                }
            });
            return i
        };
        o.prototype.getCurrentTabId = function () {
            var e = this;
            var i = e.config;
            return t(i.larry_elem).find("ul.layui-tab-title").children("li.layui-this").attr("lay-id")
        };
        o.prototype.tabAdd = function (e) {
            var n = this;
            var o = n.config;
            var f = n.exists(e.title);
            if (f == -1) {
                if (o.maxTab !== "undefined") {
                    var s = c.titleBox.children("li").length;
                    if (typeof o.maxTab === "number") {
                        if (s === o.maxTab) {
                            a.larryCmsError("为了保障系统流畅运行，默认最多只能同时打开" + o.maxTab + "个选项卡，或请设置最大打开个数", a.larryCore.tit);
                            return
                        }
                    }
                    if (typeof o.maxTab === "object") {
                        var d = o.maxTab.max || 50;
                        var u = o.maxTab.tipMsg || "为了保障系统流畅运行，默认最多只能同时打开" + d + "个选项卡。";
                        if (s === d) {
                            a.larryCmsError(u, a.larryCore.tit);
                            return
                        }
                    }
                }
                l++;
                var h = '<iframe src="' + e.href + '" data-group="' + e.group + '" data-id="' + l + '" name="ifr_' + l + '" id="ifr' + l + '"  class="larry-iframe"></iframe>';
                var y = "";
                if (e.icon !== undefined) {
                    y += '<i class="larry-icon">' + e.icon + "</i>"
                }
                y += "<em>" + e.title + "</em>";
                if (o.closed) {
                    y += '<i class="layui-icon layui-unselect layui-tab-close" data-id="' + l + '">&#x1006;</i>'
                }
                i.tabAdd(c.tabFilter, {
                    title: y,
                    content: h,
                    id: l
                });
                c.contentBox.find("iframe[data-id=" + l + "]").each(function () {
                    t(this).height(c.contentBox.height());
                    r.msg("正在加载请稍后...", {
                        icon: 6
                    })
                });
                t("#ifr" + l).load(function () {
                    parent.layer.closeAll()
                });
                if (o.closed) {
                    c.titleBox.find("li").children("i.layui-tab-close[data-id=" + l + "]").on("click",
                        function () {
                            n.deleteTab(t(this).parent("li").attr("lay-id"));
                            n.tabMove(1, 1)
                        })
                }
                var m = n.getTabId(e.title);
                n.changeTab(m);
                n.tabMove(f, 0);
                n.pageEffect(m);
                if (o.tabSession) {
                    n.session(function (t) {
                        var i = JSON.parse(t.getItem("tabMenu")) || [];
                        var r = {
                            title: e.title,
                            href: e.href,
                            icon: e.icon,
                            closed: o.closed,
                            group: e.group,
                            id: l
                        };
                        i.push(r);
                        t.setItem("tabMenu", JSON.stringify(i));
                        t.setItem("currentTabMenu", JSON.stringify(r))
                    })
                }
            } else {
                var m = n.getTabId(e.title);
                n.changeTab(m);
                if (n.config.autoRefresh) {
                    c.contentBox.children(".layui-show").find("iframe")[0].contentWindow.location.reload(true)
                }
                n.tabMove(f, 0);
                n.pageEffect(m, true)
            }
        };
        o.prototype.pageEffect = function (e, i) {
            var a = r.load(1);
            if (i) {
                c.contentBox.find("iframe[data-id=" + e + "]").css({
                    opacity: "0",
                    "margin-top": "50px"
                }).delay(100).animate({
                        opacity: "1",
                        marginTop: "0"
                    },
                    200);
                r.close(a)
            } else {
                c.contentBox.find("iframe[data-id=" + e + "]").css({
                    opacity: "0",
                    "margin-top": "50px"
                }).load(function () {
                    t(this).delay(100).animate({
                            opacity: "1",
                            marginTop: "0"
                        },
                        200);
                    r.close(a)
                })
            }
        };
        o.prototype.recoveryTab = function (e) {
            var t = this;
            var r = t.config;
            var a = t.exists(e.title);
            if (a == -1) {
                var n = '<iframe src="' + e.href + '" data-group="' + e.group + '" data-id="' + e.id + '" name="ifr_' + e.id + '" id="ifr' + e.id + '"  class="larry-iframe"></iframe>';
                var l = "";
                if (e.icon !== undefined) {
                    l += '<i class="larry-icon">' + e.icon + "</i>"
                }
                l += "<em>" + e.title + "</em>";
                if (r.closed) {
                    l += '<i class="layui-icon layui-unselect layui-tab-close" data-id="' + e.id + '">&#x1006;</i>'
                }
                i.tabAdd(c.tabFilter, {
                    title: l,
                    content: n,
                    id: e.id
                });
                t.tabMove(a, 0);
                t.pageEffect(e.id)
            } else {
                i.tabChange(c.tabFilter, t.getTabId(e.title));
                t.tabMove(a, 1);
                t.pageEffect(e.id, true)
            }
        };
        o.prototype.deleteTab = function (e) {
            var t = this;
            if (t.config.tabSession) {
                t.session(function (t) {
                    var i = JSON.parse(t.getItem("tabMenu"));
                    for (var r = 0; r < i.length; r++) {
                        if (i[r].id == e) {
                            i.splice(r, 1)
                        }
                    }
                    t.setItem("tabMenu", JSON.stringify(i));
                    var a = JSON.parse(t.getItem("currentTabMenu"));
                    if (a.id == e) {
                        t.setItem("currentTabMenu", JSON.stringify(i.pop()))
                    }
                })
            }
            i.tabDelete(t.config.tabFilter, e).init()
        };
        o.prototype.changeTab = function (e) {
            var t = this;
            if (t.config.tabSession) {
                t.session(function (t) {
                    var i = JSON.parse(t.getItem("currentTabMenu"));
                    if (!i) return false;
                    if (i.id != e) {
                        var r = JSON.parse(t.getItem("tabMenu"));
                        for (var a = 0; a < r.length; a++) {
                            if (r[a].id == e) {
                                t.setItem("currentTabMenu", JSON.stringify(r[a]));
                                break
                            }
                        }
                    }
                })
            }
            i.tabChange(t.config.tabFilter, e).init()
        };
        o.prototype.tabMove = function (e, i) {
            var a = this;
            var n = c.titleBox.find("li"),
                l = 0;
            n.each(function (e, i) {
                l += t(i).outerWidth(true)
            });
            if (!n[0]) return;
            t(window).on("resize",
                function () {
                    var a = parseInt(c.titleBox.parent("#larry_tab").width() - 270);
                    var n = parseInt(c.titleBox.find(".layui-this").outerWidth(true));
                    if (l > a) {
                        var o = a - l;
                        if (o < 0) {
                            if (e >= 0) {
                                var f = parseInt(c.titleBox.find(".layui-this").position().left);
                                var s = parseInt(c.titleBox.css("marginLeft"));
                                var d = f + parseInt(s);
                                if (d <= 0) {
                                    o = 0 - f
                                } else {
                                    var u = -(s - a + parseInt(c.titleBox.find(".layui-this").outerWidth(true)) + f);
                                    if (u <= 0) {
                                        o = a - f - parseInt(c.titleBox.find(".layui-this").outerWidth(true))
                                    } else {
                                        if (i == 1 && parseInt(s) < 0) {
                                            o = a - f - parseInt(c.titleBox.find(".layui-this").outerWidth(true));
                                            if (o > 0) {
                                                o = 0
                                            }
                                        } else if (i != 1 && parseInt(s) <= 0) {
                                            o = a - f - parseInt(c.titleBox.find(".layui-this").outerWidth(true));
                                            if (o > 0) {
                                                o = 0
                                            }
                                        } else {
                                            return
                                        }
                                    }
                                }
                            }
                            c.titleBox.css({
                                marginLeft: o
                            })
                        }
                        if (o == 0 && l < a) {
                        } else {
                            c.titleBox.find("span").remove()
                        }
                    } else {
                        c.titleBox.css({
                            marginLeft: 0
                        })
                    }
                    t(".pressKey").on("click",
                        function () {
                            if (l > a) {
                                if (t(this).attr("id") == "titleLeft") {
                                    var e = parseInt(c.titleBox.css("marginLeft"));
                                    if (Math.abs(e) + a >= l - n) {
                                        c.titleBox.css({
                                            marginLeft: a - l
                                        })
                                    } else {
                                        c.titleBox.css({
                                            marginLeft: e - a
                                        })
                                    }
                                    if (Math.abs(e) == l - a) {
                                        r.tips("已达到最右侧,别点了滚不动啦！", t(this), {
                                            tips: [1, "#FF5722"]
                                        })
                                    }
                                    return
                                }
                                if (t(this).attr("id") == "titleRight") {
                                    var e = parseInt(c.titleBox.css("marginLeft"));
                                    if (e + a < 0) {
                                        c.titleBox.css({
                                            marginLeft: e + a
                                        })
                                    } else {
                                        c.titleBox.css({
                                            marginLeft: 0
                                        })
                                    }
                                    return
                                }
                            }
                        })
                }).resize()
        };
        o.prototype.tabCtrl = function (e) {
            var i = this;
            var n = i.config;
            var l = i.getCurrentTabId();
            switch (e) {
                case "positionCurrent":
                    var o = t(n.larry_elem).find("ul.layui-tab-title").children("li.layui-this");
                    var f = t("#ifr" + l).attr("src");
                    var s = t("#ifr" + l).data("group");
                    var d = {
                        title: o.children("em").text(),
                        content: '<iframe src="' + f + '" data-group="' + s + '" data-id="' + l + '" name="ifr_' + l + '" id="ifr' + l + '"  class="larry-iframe"></iframe>',
                        id: l
                    };
                    i.tabAdd(d);
                    i.tabMove(l, 0);
                    break;
                case "closeCurrent":
                    if (l > 0) {
                        i.deleteTab(l);
                        i.tabMove(l, 1)
                    } else {
                        a.larryCmsError(a.larryCore.tit + "：默认首页不能关闭的哦！", a.larryCore.closeTit)
                    }
                    break;
                case "closeOther":
                    if (c.titleBox.children("li").length > 2) {
                        c.titleBox.children("li").each(function () {
                            var e = t(this);
                            var r = e.find("i.layui-tab-close").data("id");
                            if (r != l && r !== undefined) {
                                i.deleteTab(e.attr("lay-id"));
                                i.tabMove(l, 1)
                            }
                        })
                    } else if (c.titleBox.children("li").length == 2) {
                        a.larryCmsError(a.larryCore.tit + "：【默认首页】不能作为其他选项卡关闭！", a.larryCore.closeTit)
                    } else {
                        a.larryCmsError(a.larryCore.tit + "：当前无其他可关闭选项卡！", a.larryCore.closeTit)
                    }
                    break;
                case "closeAll":
                    if (c.titleBox.children("li").length > 1) {
                        c.titleBox.children("li").each(function () {
                            var e = t(this);
                            var r = e.find("i.layui-tab-close").data("id");
                            if (r > 0) {
                                i.deleteTab(r);
                                i.tabMove(0, 1)
                            }
                        })
                    } else {
                        a.larryCmsError(a.larryCore.tit + "：当前无其他可关闭选项卡！", a.larryCore.closeTit)
                    }
                    break;
                case "refreshAdmin":
                    r.confirm("您确定真的要重新加载后台系统界面！", {
                            title: a.larryCore.tit,
                            time: 0,
                            resize: false,
                            btn: ["我很确定", "不,我点错了"],
                            btnAlign: "c",
                            zIndex: r.zIndex,
                            anim: Math.ceil(Math.random() * 6)
                        },
                        function () {
                            location.reload()
                        },
                        function () {
                            return
                        });
                    break
            }
        };
        o.prototype.session = function (e) {
            if (!window.sessionStorage) {
                return false
            }
            e(window.sessionStorage)
        };
        function s(e, t) {
            if (t == "on") {
                var i = {
                    top: "",
                    left: []
                };
                for (var r = 0; r < e.length; r++) {
                    if (r == 0) {
                        i.top += '<li class="layui-nav-item layui-this">'
                    } else {
                        i.top += '<li class="layui-nav-item">'
                    }
                    i.top += '<a  data-group="' + r + '"">';
                    i.top += '<i class="larry-icon" data-icon="' + e[r].icon + '">' + e[r].icon + "</i>";
                    i.top += "<cite>" + e[r].title + "</cite>";
                    i.top += "</a>";
                    i.top += "</li>";
                    if (e[r].children !== undefined && e[r].children !== null && e[r].children.length > 0) {
                        i.left[r] = "";
                        for (var a = 0; a < e[r].children.length; a++) {
                            if (r == 0 && a == 0) {
                                i.left[r] += '<li class="layui-nav-item layui-this">'
                            } else if (a == 0 && (e[r].children[a].children !== undefined && e[r].children[a].children !== null && e[r].children[a].children.length > 0)) {
                                i.left[r] += '<li class="layui-nav-item layui-nav-itemed">'
                            } else if (a == 0 && !(e[r].children[a].children !== undefined && e[r].children[a].children !== null && e[r].children[a].children.length > 0)) {
                                i.left[r] += '<li class="layui-nav-item layui-this">'
                            } else if (e[r].children[a].spread && a != 0) {
                                i.left[r] += '<li class="layui-nav-item layui-nav-itemed">'
                            } else {
                                i.left[r] += '<li class="layui-nav-item">'
                            }
                            if (e[r].children[a].children !== undefined && e[r].children[a].children !== null && e[r].children[a].children.length > 0) {
                                i.left[r] += "<a>";
                                if (e[r].children[a].icon !== undefined && e[r].children[a].icon !== "") {
                                    i.left[r] += '<i class="larry-icon" data-icon="' + e[r].children[a].icon + '">' + e[r].children[a].icon + "</i>"
                                }
                                i.left[r] += "<cite>" + e[r].children[a].title + "</cite>";
                                i.left[r] += "</a>";
                                i.left[r] += '<dl class="layui-nav-child">';
                                for (var n = 0; n < e[r].children[a].children.length; n++) {
                                    if (a == 0 && n == 0) {
                                        i.left[r] += '<dd class="layui-this">'
                                    } else {
                                        i.left[r] += "<dd>"
                                    }
                                    i.left[r] += '<a data-url="' + e[r].children[a].children[n].url + '">';
                                    if (e[r].children[a].children[n].icon !== undefined && e[r].children[a].children[n].icon !== "") {
                                        i.left[r] += '<i class="larry-icon" data-icon="' + e[r].children[a].children[n].icon + '">' + e[r].children[a].children[n].icon + "</i>"
                                    }
                                    i.left[r] += "<cite>" + e[r].children[a].children[n].title + "</cite>";
                                    i.left[r] += "</a>";
                                    i.left[r] += "</dd>"
                                }
                                i.left[r] += "</dl>"
                            } else {
                                var l = e[r].children[a].url !== undefined && e[r].children[a].url !== "" ? 'data-url="' + e[r].children[a].url + '"' : "";
                                i.left[r] += "<a " + l + ">";
                                if (e[r].children[a].icon !== undefined && e[r].children[a].icon !== "") {
                                    i.left[r] += '<i class="larry-icon" data-icon="' + e[r].children[a].icon + '">' + e[r].children[a].icon + "</i>"
                                }
                                i.left[r] += "<cite>" + e[r].children[a].title + "</cite>";
                                i.left[r] += "</a>"
                            }
                            i.left[r] += "</li>"
                        }
                    }
                }
                return i
            } else {
                var o = "";
                for (var r = 0; r < e.length; r++) {
                    if (r == 0) {
                        i += '<li class="layui-nav-item layui-this">'
                    } else {
                        i += '<li class="layui-nav-item">'
                    }
                    if (e[r].children !== undefined && e[r].children !== null && e[r].children.length > 0) {
                        i += "<a>";
                        if (e[r].icon !== undefined && e[r].icon !== "") {
                            i += '<i class="larry-icon" data-icon="' + e[r].icon + '">' + e[r].icon + "</i>"
                        }
                        i += "<cite>" + e[r].title + "</cite>";
                        i += "</a>";
                        i += '<dl class="layui-nav-child">';
                        for (var a = 0; a < e[r].children.length; a++) {
                            i += "<dd>";
                            i += '<a data-url="' + e[r].children[a].url + '">';
                            if (e[r].children[a].icon !== undefined && e[r].children[a].icon !== "") {
                                i += '<i class="larry-icon" data-icon="' + e[r].children[a].icon + '">' + e[r].children[a].icon + "</i>"
                            }
                            i += "<cite>" + e[r].children[a].title + "</cite>";
                            i += "</a>";
                            i += "</dd>"
                        }
                        i += "</dl>"
                    } else {
                        var l = e[r].url !== undefined && e[r].url !== "" ? 'data-url="' + e[r].url + '"' : "";
                        i += "<a " + l + ">";
                        i += '<i class="larry-icon" data-icon="' + e[r].icon + '">' + e[r].icon + "</i>";
                        i += "<cite>" + e[r].title + "</cite>";
                        i += "</a>"
                    }
                    i += "</li>"
                }
                return i
            }
        }

        function d(e, i) {
            var r;
            if (i != "top_menu") {
                if (typeof e !== "string" && typeof e !== "object") {
                    a.larryCmsError(i + "参数未定义或设置出错", a.larryCore.paramsTit);
                    r = "error";
                    return r
                }
            } else {
                if (typeof e !== "string" && typeof e !== "object") {
                    r = "undefined";
                    return r
                }
            }
            if (typeof e === "string") {
                r = t("" + e + "")
            }
            if (typeof e === "object") {
                r = e
            }
            if (r.length === 0) {
                a.larryCmsError(i + ": 您设置了 " + i + "参数，但DOM文档中找不到定义的【 " + e + " 】元素", a.larryCore.paramsTit);
                r = "error";
                return r
            }
            var n = r.attr("lay-filter");
            if (n === undefined || n === "") {
                a.larryCmsError("请为【" + e + "】容器设置一个lay-filter过滤器", "lay-filter设置提示")
            }
            return r
        }

        function u(e) {
            var t = {
                eventName: "",
                filter: ""
            };
            if (typeof e !== "string") {
                a.larryCmsError("事件名设置错误", a.larryCore.errorTit)
            }
            var i = e.indexOf("(");
            t.eventName = e.substr(0, i);
            t.filter = e.substring(i + 1, e.indexOf(")"));
            return t
        }

        function h(e, i) {
            var r = {};
            for (var a in e) {
                if (t.inArray(a, i)) {
                    r[a] = e[a]
                }
            }
            return r
        }

        function y() {
            var e = document.cookie.match(/[^ =;]+(?=\=)/g);
            if (e) {
                for (var t = e.length; t--;) document.cookie = e[t] + "=0;expires=" + new Date(0).toUTCString()
            }
        }

        o.prototype.test = function (e, t) {
            console.log(t);
            e()
        };
        var m = new o;
        e(module_name,
            function (e) {
                return m.set(e)
            })
    });