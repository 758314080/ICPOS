layui.define(['jquery', 'form'], function(exports) {
	var $ = layui.jquery,
		form = layui.form;

	var obj = {
		init: function(settings) {
			var area = new areas();
			area.init(settings);
		}
	};

var areas = function() {
		var _this = this;
		var settings = {
				province: "", //省
				city: "", //市
				area: "", //县
				initprovince: "", //默认省
				initcity: "", //默认市
				initarea: "", //默认县

		};

		_this.init = function(options) {
			settings = $.extend(true, {}, settings, options);
			_this.getData();

		}

		_this.getData = function() {
				$.ajax({
					url: '/lhb/backstage/datas/city.json',
					type: "POST",
					dataType: "json",
					data: "Param=sheng_shi",
					success: function (data, startic) {
						if(data.status=='y'){
							settings.data = data.html;
							 return  _this.prov();
						}else{
                             alert("获取信息失败");
                             return false;
						}
					},
					error: function () {
                             alert("获取信息失败");
                             return false;
					}
				});
		}

		_this.prov = function() {

			var province=settings.province,
			citys=settings.data,
			city=settings.city,
			area=settings.area,
			initprovince=settings.initprovince,
			initcity=settings.initcity,
			initarea=settings.initarea;
			var pca = {};
			pca.keys = {};
			pca.ckeys = {};

			if(!province || !$(province).length) return; 
			$(province).html('');
			$(province).append('<option selected>全部</option>');
			//console.log(citys);
			for(var i in citys){
				$(province).append('<option value="'+citys[i].id+'">'+citys[i].name+'</option>');
				pca.keys[citys[i].id] = citys[i];
			}

					form.render('select'); //刷新select选择框渲染
					if(initprovince) $(province).next().find('[lay-value="'+initprovince+'"]').click();
					if(!city || !$(city).length) return;
					_this.formRender(city);
					form.on('select(province)', function(data){
						var cs = pca.keys[data.value];
						$(city).html('');
						$(city).append('<option>全部</option>');
						if(cs){
							cs = cs.city;  		
							for(var i in cs){
								$(city).append('<option value="'+cs[i].id+'">'+cs[i].name+'</option>');
								pca.ckeys[cs[i].id] = cs[i];
							}
							$(city).find('option:eq(1)').attr('selected', true);
						}
					form.render('select'); //刷新select选择框渲染
					$(city).next().find('.layui-this').removeClass('layui-this').click();
					//_this.formHidden('province', data.value);
			
				}); 


					if(initprovince) $(province).next().find('[lay-value="'+initprovince+'"]').click();
					if(initcity) $(city).next().find('[lay-value="'+initcity+'"]').click();
					if(!area || !$(area).length) return;
					_this.formRender(area);
					form.on('select(city)', function(data){
						var cs = pca.ckeys[data.value];
						$(area).html('');
						$(area).append('<option>全部</option>');
						if(cs){
							cs = cs.area;
							for(var i in cs){
								$(area).append('<option value="'+cs[i].id+'">'+cs[i].name+'</option>');
							}
							$(area).find('option:eq(1)').attr('selected', true);
						}
					form.render('select'); //刷新select选择框渲染
					$(area).next().find('.layui-this').removeClass('layui-this').click();
					//_this.formHidden('city', data.value);
				
				}); 
					form.on('select(area)', function(data){
				    //_this.formHidden('area', data.value);		
	
				}); 
					if(initprovince) $(province).next().find('[lay-value="'+initprovince+'"]').click();
					if(initcity) $(city).next().find('[lay-value="'+initcity+'"]').click();
					if(initarea) $(area).next().find('[lay-value="'+initarea+'"]').click();
	}


	_this.formRender = function(obj){
		$(obj).html('');
		$(obj).append('<option>全部</option>');
		form.render('select'); //刷新select选择框渲染
	}
	
	_this.formHidden = function(obj, val){
		if(!$('#pca-hide-'+obj).length) 
			$('body').append('<input id="pca-hide-'+obj+'" type="hidden" value="'+val+'" />');
		else
			$('#pca-hide-'+obj).val(val);
	}




};    
  
	//输出areas接口
	exports('city', obj);
});    