CMD ping www.google.com

go

IMPORT_EXCEL D:\Proyectos\EjecutaBI\EjecutaBIConsola\bin\Debug\ARCHIVOS
go

EXECUTE PROCEDURE sp_bi_drop('tb_bi_semanas_Normal')

Go

EXECUTE PROCEDURE sp_bi_drop('tb_bi_semanas_normales')

Go

EXECUTE PROCEDURE sp_bi_drop('Tb_Bi_Fuente_Inventario')

Go

EXECUTE PROCEDURE sp_bi_drop ('VW_BI_CTL_ARTICULOS')

Go

EXECUTE PROCEDURE sp_bi_drop('VW_BI_CTL_PERIODOS_INVENTARIOS')

Go

EXECUTE PROCEDURE sp_bi_drop('tb_bi_mala_rotacion')

Go

EXECUTE PROCEDURE sp_bi_drop('tb_bi_inventario')

Go

EXECUTE PROCEDURE sp_bi_drop('tb_bi_billoflading')

Go

EXECUTE PROCEDURE sp_bi_drop('Sp_bi_origen_referencia')

Go

EXECUTE PROCEDURE sp_bi_drop('Tb_Bi_Inventarios_Hechos')

Go

EXECUTE PROCEDURE sp_bi_drop ('VW_BI_CTL_MESES')

Go

EXECUTE PROCEDURE sp_bi_drop ('VW_BI_CTL_DIADELASEMANA')

Go

EXECUTE PROCEDURE sp_bi_drop ('VW_BI_CTL_TRANSCURRIDOS')

Go

EXECUTE PROCEDURE sp_bi_drop('VW_BI_TEMPORADA_ACTUAL')

Go

EXECUTE PROCEDURE sp_bi_drop('Vw_Bi_Ctl_TipoAnalisis')

Go

EXECUTE PROCEDURE sp_bi_drop ('VW_BI_CTL_PROVEEDORES')

Go

EXECUTE PROCEDURE sp_bi_drop ('VW_BI_CTL_PROVEEDORESMARCAS')

Go

EXECUTE PROCEDURE sp_bi_drop('Vw_Bi_Ctl_Almacenes')

Go

EXECUTE PROCEDURE sp_bi_drop('vw_bi_ctl_periodos_diasinv')

Go

EXECUTE PROCEDURE sp_bi_drop('vw_bi_ctl_analisis_INVENTARIO')

Go

EXECUTE PROCEDURE sp_bi_drop('Vw_Bi_Ctl_billoflading')

Go

EXECUTE PROCEDURE sp_bi_drop('Vw_Bi_Ctl_Curren_Day')

Go

EXECUTE PROCEDURE sp_bi_drop('SP_REP_COMPRA_DEV_BI')

Go

EXECUTE PROCEDURE sp_bi_drop('sp_bi_semanas_normales')

Go
--- Incia creacion de Catalogos
CREATE VIEW VW_BI_CTL_MESES(
    CVE_MES,
    DES_MES)
AS
Select '01' as cve_Mes,'04 - January' as des_Mes from NEW_TABLE
UNION ALL  
Select '02' as cve_Mes,'05 - February' as des_Mes from NEW_TABLE
UNION ALL  
Select '03' as cve_Mes,'06 - March' as des_Mes from NEW_TABLE
UNION ALL  
Select '04' as cve_Mes,'07 - April' as des_Mes from NEW_TABLE
UNION ALL  
Select '05' as cve_Mes,'08 - May' as des_Mes from NEW_TABLE
UNION ALL  
Select '06' as cve_Mes,'09 - June' as des_Mes from NEW_TABLE
UNION ALL  
Select '07' as cve_Mes,'10 - July' as des_Mes from NEW_TABLE
UNION ALL  
Select '08' as cve_Mes,'11 - August' as des_Mes from NEW_TABLE
UNION ALL  
Select '09' as cve_Mes,'12 - September' as des_Mes from NEW_TABLE
UNION ALL  
Select '10' as cve_Mes,'01 - October' as des_Mes from NEW_TABLE
UNION ALL  
Select '11' as cve_Mes,'02 - November' as des_Mes from NEW_TABLE
UNION ALL  
Select '12' as cve_Mes,'03 - December' as des_Mes from NEW_TABLE
where 1=1

Go

CREATE VIEW VW_BI_CTL_DIADELASEMANA(
    CVE_DIADELASEMANA,
    DES_DIADELASEMANA)
AS
select '01' as cve_DiaDeLaSemana,'1 - Monday' as des_DiaDeLaSemana  from new_table
union all
select '02' as cve_DiaDeLaSemana,'2 - Tuesday' as des_DiaDeLaSemana  from new_table
union all
select '03' as cve_DiaDeLaSemana,'3 - Wednesday' as des_DiaDeLaSemana  from new_table
union all
select '04' as cve_DiaDeLaSemana,'4 - Thursday' as des_DiaDeLaSemana   from new_table
union all
select '05' as cve_DiaDeLaSemana,'5 - Friday' as des_DiaDeLaSemana  from new_table
union all
select '06' as cve_DiaDeLaSemana,'6 - Saturday' as des_DiaDeLaSemana    from new_table
union all
select '07' as cve_DiaDeLaSemana,'7 - Sunday' as des_DiaDeLaSemana   from new_table
where 1=1

Go

CREATE VIEW VW_BI_CTL_TRANSCURRIDOS(
    CVE_TRANSCURRIDO,
    DES_TRANSCURRIDO)
AS
Select 1 as cve_Transcurrido,'01 - Elapsed days' as des_Transcurrido   from new_table
UNION ALL  
Select 2 as cve_Transcurrido,'02 - Remaining days' as des_Transcurrido from new_table
where 1=1

Go

CREATE VIEW VW_BI_TEMPORADA_ACTUAL(
    CVE_TEMPORADA_ACTUAL,
    DES_TEMPORADA_ACTUAL)
AS
select
1 as Cve_Temporada_Actual,
'CURRENT SEASON' as Des_Temporada_Actual from new_table
union all
select
2 as Cve_Temporada_Actual,
'LAST SEASON' as Des_Temporada_Actual from new_table
union all
select
3 as Cve_Temporada
,'OTHER' as des_Temporada_Actual from new_table

Go

CREATE VIEW VW_BI_CTL_TIPOANALISIS(
    CVE_TIPOANALISIS,
    DES_TIPOANALISIS)
AS
Select 1 as cve_TipoAnalisis, '01 - Amount' as des_TipoAnalisis from new_table
union all
Select 2 as cve_TipoAnalisis, '02 - Lbs' as des_TipoAnalisis from new_table
union all
Select 3 as cve_TipoAnalisis, '03 - Kg' as des_TipoAnalisis from new_table

Go

CREATE VIEW VW_BI_CTL_PROVEEDORES(
    CVE_PROVEEDOR,
    DES_PROVEEDOR_CORTO,
    DES_PROVEEDOR_LARGO)
AS
select 0 as cve_proveedor,'-NO VENDOR' as des_proveedor_corto,'-NO VENDOR' as des_proveedor_Largo from new_table
union all
select
    id as cve_Proveedor
    ,nombre as des_Proveedor_Corto
    ,descripcion as des_Proveedor_Largo
from tb_c_proveedores

Go

CREATE VIEW VW_BI_CTL_PROVEEDORESMARCAS(
    CVE_PROVEEDOR_MARCA,
    DES_PROVEEDOR_MARCACORTA,
    DES_PROVEEDOR_MARCA)
AS
Select
 id as CVE_PROVEEDOR_MARCA
,NOMBRE as des_Proveedor_MarcaCorta
,DESCRIPCION as des_Proveedor_Marca
from TB_C_Proveedores_Marcas
where 1=1
UNION
Select
0 as CVE_PROVEEDOR_MARCA,
'- PROVIDER NO BRAND' as DES_PROVEEDOR_MARCACORTA,
'- PROVIDER NO BRAND' as DES_PROVEEDOR_MARCA
from New_Table

Go

CREATE VIEW VW_BI_CTL_ALMACENES(
    CVE_ALMACEN,
    DES_ALAMACEN_CORTO,
    DES_ALMACEN_LARGO,
    CVE_ALMACEN_LOCALIZ,
    DES_ALMACEN_LOCALIZ)
AS
select 0 as cve_almacen
,'NO WAREHOUSE' as cve_almacen_corto
,'NO WAREHOUSE' as des_Almacen_Largo
,0 as cve_almacen_localiz
,'NO WAREHOUSE' as des_almacen_localiz from new_table
union all
Select
     g.ID as cve_Almacen
    ,g.nombre as des_Alamacen_Corto
    ,g.descripcion as des_Almacen_Largo
    ,f.ID as cve_Almacen_localiz
    ,f.nombre as des_Almacen_localiz
from tb_c_almacenes_localiz f
left join tb_c_almacenes g
on f.almacen_id = g.id

Go

CREATE VIEW VW_BI_CTL_PERIODOS_DIASINV(
    CVE_DIAS,
    DES_DIAS)
AS
select 1 as cve_dias,'today' as des_dias from new_table
union all
select 2 as cve_dias,'1 day' as des_dias from new_table
union all
select 3 as cve_dias,'2 days' as des_dias from new_table
union all
select 4 as cve_dias,'3 days' as des_dias from new_table
union all
select 5 as cve_dias,'4 days' as des_dias from new_table
union all
select 6 as cve_dias,'5 days' as des_dias from new_table
union all
select 7 as cve_dias,'6 days' as des_dias from new_table
union all
select 8 as cve_dias,'7 days' as des_dias from new_table
union all
select 9 as cve_dias,'> 7 days' as des_dias from new_table
union all
select 10 as cve_dias,'> 12 days' as des_dias from new_table

Go

CREATE VIEW VW_BI_CTL_ANALISIS_INVENTARIO(
    CVE_ANALISIS,
    DES_ANALISIS)
AS
Select 1 as cve_analisis,'CURRENT INVENTORY' AS Des_analisis from new_table
union all
select 2 as cve_analisis,'ROTATION INVENTORY BY MANIFEST' as des_analisis from new_table
union all
select 3 as cve_analisis,'ROTATION INVENTORY BY BILL OF LADING' as des_analisis from new_table
union all
select 4 as cve_analisis,'HISTORIC INVENTORY' as des_analisis from new_table

Go

CREATE VIEW VW_BI_CTL_CURREN_DAY(
    CVE_CURRENT_DAY,
    DES_CURRENT_DAY)
AS
Select 1 as Cve_Current_Day,'Current Day' as Des_Current_Day from New_Table
Union All
Select 2 as Cve_Current_Day,'Last Day' as Des_Current_Day from New_Table
Union All
Select 0 as Cve_Current_Day,'Other' as Des_Current_Day from New_Table

Go

create table tb_bi_semanas_normales(
cve_Temporada varchar(5),
cve_Mes integer, 
Cve_Semana char(2),
FechaIni date,
FechaFin date)

Go

create Procedure sp_bi_semanas_normales
(fechaIni date,
fechaFin date)
as
declare variable Tope date;
declare variable Semana int;
Begin
Tope = FechaFin;
FechaFin = :FechaIni + 6;

while (:FechaIni <= :Tope)do
begin
Semana = 1;
 while (:Semana <= 52)do
 begin
  if ((:FechaIni = cast('12-28-2009' as date)) or
      (:FechaIni = cast('12-28-2015' as date)) or
      (:FechaIni = cast('12-28-2020' as date)) or
      (:FechaIni = cast('12-28-2026' as date)) or
      (:FechaIni = cast('12-27-2032' as date)) or
      (:FechaIni = cast('12-28-2037' as date))) then
  begin
    Semana = 53;
    end

 Insert Into tb_bi_semanas_normales
 select
  case
       when extract(month from cast(substring(:FechaIni from 1 for 10) as date)) in (10,11,12) then
       substring(cast(extract(year from cast(substring(:FechaIni from 1 for 10) as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(substring(:FechaIni from 1 for 10) as date))+1 as char(4)) from 3 for 2)

       when extract(month from cast(substring(:FechaIni from 1 for 10) as date)) in (1,2,3,4,5,6,7,8,9) then
       substring(cast(extract(year from cast(substring(:FechaIni from 1 for 10) as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(substring(:FechaIni from 1 for 10) as date)) as char(4)) from 3 for 2)
      end as cve_Temporada,
  Extract(month from :FechaIni ) as cve_mes,
  case
   when (:Semana < 10)then
   cast((0||:Semana) as char(2))
   else
   cast(:Semana as char(2))
   end as cve_semana,
:FechaIni as cve_FechaIni,
:FechaFin as cve_FechaFin
from new_table;
FechaIni = :FechaIni + 7;
FechaFin = FechaFin + 7;
Semana = :Semana +1;
 end
end
suspend;
end

Go

execute procedure sp_bi_semanas_normales('01-01-2007','01-04-2038')

Go

CREATE VIEW VW_BI_CTL_ARTICULOS(
    CVE_ARTICULO,
    DES_ARTICULOCORTA,
    DES_ARTICULO,
    CVE_ARTICULOCLASE,
    DES_ARTICULOCLASECORTA,
    DES_ARTICULOCLASE,
    CVE_ARTICULO_TIPO,
    DES_ARTICULOTIPOCORTA,
    DES_ARTICULOTIPO,
    CVE_ARTICULOUNIDAD,
    DES_ARTICULOUNIDADCORTA,
    DES_ARTICULOUNIDADCORTASINGULAR,
    DES_ARTICULOUNIDAD)
AS
Select
 a.id as cve_vd_Articulo
,coalesce(a.nombre,'') as des_ArticuloCorta,coalesce(a.descripcion,'') as des_Articulo
,coalesce(a.Articulo_clase_id,0) as cve_ArticuloClase
,coalesce(ac.NOMBRE,'') as des_ArticuloClaseCorta,coalesce(ac.DESCRIPCION,'') as des_ArticuloClase
,coalesce(a.articulo_tipo_id,0) as cve_ArticuloTipo
,coalesce(atp.NOMBRE,'') as des_ArticuloTipoCorta
,coalesce(atp.DESCRIPCION,'') as des_ArticuloTipo
,coalesce(a.articulo_um_id,0) as cve_ArticuloUnidad
,coalesce(aum.nombre,'') as des_ArticuloUnidadCorta
,coalesce(aum.nombre_singular,'') as des_ArticuloUnidadCortaSingular
,coalesce(aum.descripcion,'') as des_ArticuloUnidad
from Tb_C_Articulos a
join Tb_c_Articulos_Clases  ac on (a.Articulo_clase_id=ac.ID)
left join Tb_c_Articulos_Tipos  atp on (a.articulo_tipo_id=atp.ID)
left join Tb_c_Articulos_um aum on (a.articulo_um_id=aum.id)
where 1=1
UNION ALL
Select
0 as CVE_VD_ARTICULO,
'- No DESCRIPTION' as DES_ARTICULOCORTA,
'- No ARTICLE' as DES_ARTICULO,
0 as CVE_ARTICULOCLASE,
'- NO CLASS' as DES_ARTICULOCLASECORTA,
'- NO CLASS' as DES_ARTICULOCLASE,
0 as CVE_ARTICULOTIPO,
'- UNTYPE' as DES_ARTICULOTIPOCORTA,
'- UNTYPE' as DES_ARTICULOTIPO,
0 as CVE_ARTICULOUNIDAD,
'- NO UNIT' as DES_ARTICULOUNIDADCORTA,
'- NO UNIT' as DES_ARTICULOUNIDADCORTASINGULAR,
'- NO UNIT' as DES_ARTICULOUNIDAD
 from New_Table

Go

create table Tb_Bi_Fuente_Inventario(
ID integer,
CVE_COMPRA_DET integer,
CVE_COMPRA_REC_DET integer,
CVE_INV_AJUSTE_DET integer,
CVE_PAGO_DET integer,
CVE_ALMACEN_LOCALIZ integer,
CVE_PROVEEDOR integer,
NUM_CANTIDAD_INVENTARIO numeric(18,12),
NUM_CANTIDAD_COMPRAS numeric(18,12),
NUM_CANTIDAD_VENTAS numeric(18,12),
MUN_CANTIDAD_DEVUELTA numeric(18,12),
MUN_CANTIDAD_COMPROMETIDA numeric(18,12),
NUM_DIAS_INVENTARIO integer,
NUM_CANTIDAD_DISPONIBLE numeric(18,4),
CVE_DOC_ID integer,
CVE_DOC_DET_ID integer,
CVE_DOC_TIPO varchar(11),
CVE_DOCUMENTO varchar(18),
DFECHA_DOCUMENTO date,
CVE_TIPO varchar(5),
CVE_ARTICULO_TIPO integer,
CVE_ARTICULO integer,
CVE_PROVEEDOR_MARCA integer,
CVE_CUENTA_VENTAS_ID integer,
CVE_CUENTA_INVENTARIO_ID integer,
CVE_CUENTA_COSTO_VENTAS_ID integer,
CVE_CUENTA_COMISION_ID integer,
NUM_COSTO numeric(18,4),
CVE_TIPOANALISIS integer,
DFECHA_MANIFIESTO date
)

Go

/*PREPARACION DE LA FUENTE DE HECHOS PARA INVENTARIOS*/


---Fuente para reporte Detalle de Inventario(Inventory Detail)
---Existencia en Cantidad
insert into tb_bi_fuente_inventario
select
    a.ID,
    coalesce(a.COMPRA_DET_ID,0) as cve_Compra_det,
    coalesce(a.COMPRA_REC_DET_ID,0) as cve_Compra_rec_det,
    coalesce(a.INV_AJUSTE_DET_ID,0) as cve_Inv_ajuste_det,
    coalesce(a.PAGO_DET_ID,0) as cve_Pago_det,
    --coalesce(a.ARTICULO_ID,0) as cve_Articulo,
    --coalesce(a.PROVEEDOR_MARCA_ID,0) as cve_Proveedor_marca,
    coalesce(a.ALMACEN_LOCALIZ_ID,0) as cve_Almacen_localiz,
    coalesce(a.PROVEEDOR_ID,0) as cve_Proveedor,
    coalesce(a.CANT_INVENTARIO,0) as num_Cantidad_inventario,
    coalesce(a.CANT_COMPRAS,0) as num_Cantidad_compras,
    coalesce(a.CANT_VENTAS,0) as num_Cantidad_ventas,
    coalesce(a.CANT_DEVUELTA,0) as mun_Cantidad_devuelta,
    coalesce(a.cant_comprometida,0) as num_Cantidad_comprometida,
    current_date - coalesce(b.DOC_FECHA,current_date)  as num_dias_inventario,

    coalesce((A.CANT_INVENTARIO+A.CANT_COMPRAS-A.CANT_VENTAS),0) as num_Cantidad_disponible,
    coalesce(b.DOC_ID,0)             as cve_Doc_id,
    coalesce(b.DOC_DET_ID,0)         as cve_Doc_det_id,
    coalesce(b.DOC_TIPO,0)           as cve_Doc_tipo,
    coalesce(b.DOC_NO,0)             as cve_Documento,
    coalesce(b.DOC_FECHA,current_date)          as Dfecha_DOC,
    coalesce(b.TIPO,'STP')               as cve_Tipo,
    coalesce(d.cve_articulo_tipo,0) as cve_Articulo_Tipo,
    coalesce(b.ARTICULO_ID,0)        as cve_Articulo,
    coalesce(b.PROVEEDOR_MARCA_ID,0) as cve_Proveedor_marca,
    --coalesce(a.ALMACEN_LOCALIZ_ID,0) as cve_Almacen_localiz_id,
    coalesce(b.cuenta_ventas_id,0) as cve_Cuenta_ventas_id,
    coalesce(b.cuenta_inventario_id,0) as cve_Cuenta_inventario_id,
    coalesce(b.cuenta_costo_ventas_id,0) as cve_Cuenta_costo_ventas_id,
    coalesce(b.cuenta_comision_id,0) as cve_Cuenta_comision_id,
    coalesce(b.costo,0) as num_Costo,
    1 as cve_TipoAnalisis,
    cast(coalesce(cast(f.fecha_recibo as date),'10-01-1901') as date) as dfecha_manifiesto
from tb_inventario a
left join sp_inventario_info2(a.articulo_id,a.proveedor_marca_id, a.compra_det_id, a.compra_rec_det_id, a.inv_ajuste_det_id,a.pago_det_id) b on 1=1
left join tb_c_articulos c on b.articulo_id = c.id
left join vw_bi_ctl_articulos d on c.id = d.cve_Articulo
left join tb_compras_rec_det e on a.compra_rec_det_id = e.id
left join tb_compras_rec f on e.compra_rec_id = f.id
where  
((a.CANT_INVENTARIO<>0) or (a.CANT_COMPRAS<>0)
or (a.CANT_VENTAS<>0) or (a.CANT_DEVUELTA<>0))



union all

---Fuente para reporte Detalle de Inventario(Inventory Detail)
---Existencia en Libras
select
    a.ID,
    coalesce(a.COMPRA_DET_ID,0) as cve_Compra_det,
    coalesce(a.COMPRA_REC_DET_ID,0) as cve_Compra_rec_det,
    coalesce(a.INV_AJUSTE_DET_ID,0) as cve_Inv_ajuste_det,
    coalesce(a.PAGO_DET_ID,0) as cve_Pago_det,
    --coalesce(a.ARTICULO_ID,0) as cve_Articulo,
    --coalesce(a.PROVEEDOR_MARCA_ID,0) as cve_Proveedor_marca,
    coalesce(a.ALMACEN_LOCALIZ_ID,0) as cve_Almacen_localiz,
    coalesce(a.PROVEEDOR_ID,0) as cve_Proveedor,
    coalesce(coalesce(a.CANT_INVENTARIO,0) * c.pesoxum,0) as num_Cantidad_inventario,
    coalesce(coalesce(a.CANT_COMPRAS,0) * c.pesoxum,0) as num_Cantidad_compras,
    coalesce(coalesce(a.CANT_VENTAS,0) * c.pesoxum,0) as num_Cantidad_ventas,
    coalesce(coalesce(a.CANT_DEVUELTA,0) * c.pesoxum,0) as mun_Cantidad_devuelta,
    coalesce(coalesce(a.cant_comprometida,0) * c.pesoxum,0) as num_Cantidad_comprometida,
    current_date - coalesce(b.DOC_FECHA,current_date)  as num_dias_inventario,

    coalesce((A.CANT_INVENTARIO+A.CANT_COMPRAS-A.CANT_VENTAS) * c.pesoxum,0) as num_Cantidad_disponible,
    coalesce(b.DOC_ID,0)             as cve_Doc_id,
    coalesce(b.DOC_DET_ID,0)         as cve_Doc_det_id,
    coalesce(b.DOC_TIPO,0)           as cve_Doc_tipo,
    coalesce(b.DOC_NO,0)             as cve_Documento,
    coalesce(b.DOC_FECHA,current_date)          as Dfecha_DOC,
    coalesce(b.TIPO,'STP')               as cve_Tipo,
    coalesce(d.cve_articulo_tipo,0) as cve_Articulo_Tipo,
    coalesce(b.ARTICULO_ID,0)        as cve_Articulo,
    coalesce(b.PROVEEDOR_MARCA_ID,0) as cve_Proveedor_marca,
    --coalesce(a.ALMACEN_LOCALIZ_ID,0) as cve_Almacen_localiz_id,
    coalesce(b.cuenta_ventas_id,0) as cve_Cuenta_ventas_id,
    coalesce(b.cuenta_inventario_id,0) as cve_Cuenta_inventario_id,
    coalesce(b.cuenta_costo_ventas_id,0) as cve_Cuenta_costo_ventas_id,
    coalesce(b.cuenta_comision_id,0) as cve_Cuenta_comision_id,
    coalesce(b.costo,0) as num_Costo,
    2 as cve_TipoAnalisis,
    cast(coalesce(cast(f.fecha_recibo as date),'10-01-1901') as date) as dfecha_manifiesto
from tb_inventario a
left join sp_inventario_info2(a.articulo_id,a.proveedor_marca_id, a.compra_det_id, a.compra_rec_det_id, a.inv_ajuste_det_id,a.pago_det_id) b on 1=1
left join tb_c_articulos c on b.articulo_id = c.id
left join vw_bi_ctl_articulos d on c.id = d.cve_Articulo
left join tb_compras_rec_det e on a.compra_rec_det_id = e.id
left join tb_compras_rec f on e.compra_rec_id = f.id
where  
((a.CANT_INVENTARIO<>0) or (a.CANT_COMPRAS<>0)
or (a.CANT_VENTAS<>0) or (a.CANT_DEVUELTA<>0))

union all

---Fuente para reporte Detalle de Inventario(Inventory Detail)
---Existencia en Kilos
select
    a.ID,
    coalesce(a.COMPRA_DET_ID,0) as cve_Compra_det,
    coalesce(a.COMPRA_REC_DET_ID,0) as cve_Compra_rec_det,
    coalesce(a.INV_AJUSTE_DET_ID,0) as cve_Inv_ajuste_det,
    coalesce(a.PAGO_DET_ID,0) as cve_Pago_det,
    --coalesce(a.ARTICULO_ID,0) as cve_Articulo,
    --coalesce(a.PROVEEDOR_MARCA_ID,0) as cve_Proveedor_marca,
    coalesce(a.ALMACEN_LOCALIZ_ID,0) as cve_Almacen_localiz,
    coalesce(a.PROVEEDOR_ID,0) as cve_Proveedor,
    coalesce(coalesce(a.CANT_INVENTARIO,0) * c.pesoxum * 0.4536,0) as num_Cantidad_inventario,
    coalesce(coalesce(a.CANT_COMPRAS,0) * c.pesoxum * 0.4536,0) as num_Cantidad_compras,
    coalesce(coalesce(a.CANT_VENTAS,0) * c.pesoxum * 0.4536,0) as num_Cantidad_ventas,
    coalesce(coalesce(a.CANT_DEVUELTA,0) * c.pesoxum * 0.4536,0) as mun_Cantidad_devuelta,
    coalesce(coalesce(a.cant_comprometida,0) * c.pesoxum * 0.4536,0) as num_Cantidad_comprometida,
    current_date - coalesce(b.DOC_FECHA,current_date)  as num_dias_inventario,

    coalesce((A.CANT_INVENTARIO+A.CANT_COMPRAS-A.CANT_VENTAS) * c.pesoxum * 0.4536,0) as num_Cantidad_disponible,
    coalesce(b.DOC_ID,0)             as cve_Doc_id,
    coalesce(b.DOC_DET_ID,0)         as cve_Doc_det_id,
    coalesce(b.DOC_TIPO,0)           as cve_Doc_tipo,
    coalesce(b.DOC_NO,0)             as cve_Documento,
    coalesce(b.DOC_FECHA,current_date)          as Dfecha_DOC,
    coalesce(b.TIPO,'STP')               as cve_Tipo,
    coalesce(d.cve_articulo_tipo,0) as cve_Articulo_Tipo,
    coalesce(b.ARTICULO_ID,0)        as cve_Articulo,
    coalesce(b.PROVEEDOR_MARCA_ID,0) as cve_Proveedor_marca,
    --coalesce(a.ALMACEN_LOCALIZ_ID,0) as cve_Almacen_localiz_id,
    coalesce(b.cuenta_ventas_id,0) as cve_Cuenta_ventas_id,
    coalesce(b.cuenta_inventario_id,0) as cve_Cuenta_inventario_id,
    coalesce(b.cuenta_costo_ventas_id,0) as cve_Cuenta_costo_ventas_id,
    coalesce(b.cuenta_comision_id,0) as cve_Cuenta_comision_id,
    coalesce(b.costo,0) as num_Costo,
    3 as cve_TipoAnalisis,
    cast(coalesce(cast(f.fecha_recibo as date),'10-01-1901') as date) as dfecha_manifiesto
from tb_inventario a
left join sp_inventario_info2(a.articulo_id,a.proveedor_marca_id, a.compra_det_id, a.compra_rec_det_id, a.inv_ajuste_det_id,a.pago_det_id) b on 1=1
left join tb_c_articulos c on b.articulo_id = c.id
left join vw_bi_ctl_articulos d on c.id = d.cve_Articulo
left join tb_compras_rec_det e on a.compra_rec_det_id = e.id
left join tb_compras_rec f on e.compra_rec_id = f.id
where  
((a.CANT_INVENTARIO<>0) or (a.CANT_COMPRAS<>0)
or (a.CANT_VENTAS<>0) or (a.CANT_DEVUELTA<>0))

Go

Create procedure Sp_bi_origen_referencia(
    compra_rec_det_id integer)
    returns(Orden_compra varchar(18))
as
declare variable compra_dev_det_id integer;
declare variable compra_det_id integer;
declare variable compra_id integer;
declare variable compra_rec_id integer;
begin
select compra_dev_det_id from tb_compras_rec_det where id = :compra_rec_det_id
into :compra_dev_det_id;

if (:compra_dev_det_id is not null) then
begin

 select compra_det_id from tb_compras_dev_det where id = :compra_dev_det_id
 into :compra_det_id;

 select compra_id from tb_compras_det where id = :compra_det_id
 into :compra_id;

 select orden_compra from tb_compras where id = :compra_id
 into :Orden_compra;
 if (:orden_compra is null) then
 begin
  select compra_rec_id from tb_compras_rec_det where id = :compra_rec_det_id
  into :compra_rec_id;

  select referencia from tb_compras_rec where id = :compra_rec_id
  into :Orden_compra;
 end

end else
begin

 select compra_rec_id from tb_compras_rec_det where id = :compra_rec_det_id
 into :compra_rec_id;

 select referencia from tb_compras_rec where id = :compra_rec_id
 into :Orden_compra;
end
suspend;
end

Go

create procedure Sp_bi_Fecha_Manifiesto(
    compra_rec_det_id integer)
    returns(fecha_recibo date)
as
declare variable compra_dev_det_id integer;
declare variable compra_det_id integer;
declare variable compra_id integer;
declare variable compra_rec_id integer;
declare variable Orden_compra varchar(18);
begin
select compra_dev_det_id from tb_compras_rec_det where id = :compra_rec_det_id
into :compra_dev_det_id;

if (:compra_dev_det_id is not null) then
begin

 select compra_det_id from tb_compras_dev_det where id = :compra_dev_det_id
 into :compra_det_id;

 select compra_id from tb_compras_det where id = :compra_det_id
 into :compra_id;

 select orden_compra from tb_compras where id = :compra_id
 into :Orden_compra;
 if (:orden_compra is null) then
 begin
  select compra_rec_id from tb_compras_rec_det where id = :compra_rec_det_id
  into :compra_rec_id;

  select fecha_recibo from tb_compras_rec where id = :compra_rec_id
  into :fecha_recibo;
 end

end else
begin

 select compra_rec_id from tb_compras_rec_det where id = :compra_rec_det_id
 into :compra_rec_id;

 select fecha_recibo from tb_compras_rec where id = :compra_rec_id
 into :fecha_recibo;
end
suspend;
end


Go

create GENERATOR gen_t1_id3

Go

SET GENERATOR gen_t1_id3 TO 0

Go

create table tb_bi_billoflading(
CVE_ID INTEGER,
CVE_ENTREGADOR INTEGER,
DFECHA_MANIFIESTO DATE,
CVE_MANIFIESTO VARCHAR(20),
CVE_BILL_OF_LADING VARCHAR(20),
COMPRA_REC_DET_ID INTEGER,
CVE_ARTICULO INTEGER,
CVE_PRODUCTO INTEGER,
NUM_CANT_ENTREGADA INTEGER,
DFECHA DATE,
CVE_CLIENTE INTEGER,
CVE_ALMACEN INTEGER,
CVE_PROVEEDOR_MARCA INTEGER
)

Go

create TRIGGER T1_BI3 FOR tb_bi_billoflading
ACTIVE BEFORE INSERT POSITION 0
AS
BEGIN
if (NEW.CVE_ID is NULL) then NEW.CVE_ID = GEN_ID(GEN_T1_ID3, 1);
END

Go

INSERT INTO tb_bi_billoflading
select
NULL,
ENTREGADOR_ID,
(select cast(fecha_recibo as date) from Sp_bi_Fecha_Manifiesto(tved.COMPRA_REC_DET_ID)) as dfecha_manifiesto,
(select * from sp_bi_origen_referencia(tved.COMPRA_REC_DET_ID)) as manifiesto,
ENTREGA_NO as CVE_BILL_OF_LADING,
tved.compra_rec_det_id,
(select id from tb_c_articulos a where tved.descripcion_memo = a.descripcion ) as cve_Articulo,
(select articulo_tipo_id from tb_c_articulos a where tved.descripcion_memo = a.descripcion ) as cve_Producto,
cast(tved.cant_entregada as integer) as num_Cant_Entregada,
FECHA_ENTREGA,
CLIENTE_ID,
h.almacen_id as cve_almacen,
(select id from tb_c_proveedores_marcas a where a.activo = 1 and a.nombre = tved.proveedor_marca_nombre) as CVE_PROVEEDOR_MARCA
from tb_ventas_entr tve
inner join  tb_ventas_entr_det tved on  tve.id=tved.venta_entr_id
inner join tb_compras_rec_det b on tved.compra_rec_det_id=b.id
inner join tb_c_almacenes_localiz h on tved.almacen_localiz_id = h.id
where fecha_entrega between (current_date - 5) and current_date
order by FECHA_ENTREGA,ENTREGA_NO,(select id from tb_c_articulos a where tved.descripcion_memo = a.descripcion ),(select id from tb_c_proveedores_marcas a where a.activo = 1 and a.nombre = tved.proveedor_marca_nombre),h.almacen_id,(select * from sp_bi_origen_referencia(tved.COMPRA_REC_DET_ID))

Go

CREATE VIEW VW_BI_CTL_BILLOFLADING(
    CVE_BILLOFLADING,
    DES_BILLOFLADING)
AS
Select cve_id,CVE_BILL_OF_LADING from tb_bi_billoflading

Go

create table tb_bi_inventario(
CVE_COMPRA_REC_DET INTEGER,
CVE_ALMACEN INTEGER,
CVE_PROVEEDOR INTEGER,
CVE_PROVEEDOR_MARCA integer, 
NUM_CANTIDAD_INVENTARIO INTEGER,
CVE_DOCUMENTO VARCHAR(20),
DFECHA_DOCUMENTO DATE,
CVE_ARTICULO_TIPO INTEGER,
CVE_ARTICULO INTEGER,
DFECHA_MANIFIESTO DATE,
STATUS integer
)

Go

INSERT INTO tb_bi_inventario
Select
ompra_rec_det_id CVE_COMPRA_REC_DET,
h.almacen_id as CVE_ALMACEN,
a.proveedor_id as CVE_PROVEEDOR,
g.proveedor_marca_id as CVE_PROVEEDOR_MARCA,
cast(cant_inventario as integer) as NUM_CANTIDAD_INVENTARIO,
(select * from sp_bi_origen_referencia(OMPRA_REC_DET_ID)) as CVE_DOCUMENTO,
fecha_inventario as DFECHA_DOCUMENTO,
(Select articulo_tipo_id from tb_c_Articulos c where b.descripcion_memo=c.descripcion) as CVE_ARTICULO_TIPO,
(Select id from tb_c_Articulos c where b.descripcion_memo=c.descripcion)as CVE_ARTICULO,
(select cast(fecha_recibo as date) from Sp_bi_Fecha_Manifiesto(a.OMPRA_REC_DET_ID)) as dfecha_manifiesto,
case when (a.CANT_COMPROMETIDA <> 0)then 1 else 0 end status
from tb_bi_historico_inventario a
inner join tb_compras_rec_det b on a.ompra_rec_det_id=b.id
inner join tb_compras_det g on a.compra_det_id = g.id
inner join tb_c_almacenes_localiz h on a.almacen_localiz_id = h.id
where a.cant_inventario <>0  and fecha_inventario between (current_date - 5) and current_date
order by fecha_inventario,(Select id from tb_c_Articulos c where b.descripcion_memo=c.descripcion),g.proveedor_marca_id,h.almacen_id,(select * from sp_bi_origen_referencia(OMPRA_REC_DET_ID))

Go

create table tb_bi_mala_rotacion(
CVE_COMPRA_REC_DET INTEGER,
CVE_ALMACEN INTEGER,
CVE_PROVEEDOR INTEGER,
CVE_PROVEEDOR_MARCA integer, 
NUM_CANTIDAD_INVENTARIO INTEGER,
CVE_DOCUMENTO VARCHAR(20),
DFECHA_DOCUMENTO DATE,
CVE_ARTICULO_TIPO INTEGER,
CVE_ARTICULO INTEGER,
DFECHA_MANIFIESTO DATE,
cve_billoflading INTEGER
)

Go

create table tb_mala_rotacion_billoflading(
CVE_BILL_OF_LADING varchar(7),
CVE_COMPRA_REC_DET INTEGER,
CVE_ALMACEN INTEGER,
CVE_PROVEEDOR INTEGER,
CVE_PROVEEDOR_MARCA integer, 
NUM_CANTIDAD_INVENTARIO INTEGER,
CVE_DOCUMENTO VARCHAR(20),
DFECHA_DOCUMENTO DATE,
CVE_ARTICULO_TIPO INTEGER,
CVE_ARTICULO INTEGER,
DFECHA_MANIFIESTO DATE,
cve_billoflading INTEGER
)

Go

create Procedure sp_bi_verifica_rotacion
as
declare variable cont integer;
declare variable tope integer;
declare variable fecha_manifiesto date;
declare variable cve_articulo integer;
declare variable maifiesto varchar(20);
declare variable fecha date;
declare variable var integer;
declare variable cve_compra_rec_det integer;
declare variable cve_almacen integer;
declare variable cve_proveedor_marca integer;
Begin
cont = 0;
select count(1) from tb_bi_billoflading
into :tope;

while (:cont <= :tope) Do
Begin

  select dfecha,cve_articulo,cve_proveedor_marca,cve_almacen,dfecha_manifiesto,cve_manifiesto,compra_rec_det_id from tb_bi_billoflading where cve_id = :cont
  into :fecha,:cve_articulo,:cve_proveedor_marca,:cve_almacen,:fecha_manifiesto,:maifiesto,:cve_compra_rec_det;

      If (exists(select * from tb_bi_inventario where dfecha_documento = :fecha and status = 0 and cve_articulo = :cve_articulo and cve_proveedor_marca = :cve_proveedor_marca and CVE_ALMACEN = :cve_almacen and cve_documento <> :maifiesto and dfecha_manifiesto < :fecha_manifiesto)) then
        Begin

        Insert Into tb_bi_mala_rotacion
        select
          CVE_COMPRA_REC_DET,
          CVE_ALMACEN,
          CVE_PROVEEDOR,
          CVE_PROVEEDOR_MARCA,
          NUM_CANTIDAD_INVENTARIO,
          CVE_DOCUMENTO,
          DFECHA_DOCUMENTO,
          CVE_ARTICULO_TIPO,
          CVE_ARTICULO,
          DFECHA_MANIFIESTO,
          :cont as cve_billoflading
        from tb_bi_inventario
        where dfecha_documento = :fecha and status = 0 and cve_articulo = :cve_articulo and cve_proveedor_marca = :cve_proveedor_marca and CVE_ALMACEN = :cve_almacen and cve_documento <> :maifiesto and dfecha_manifiesto < :fecha_manifiesto
        order by dfecha_manifiesto;
        End
        Cont = :Cont + 1;
End
 insert into tb_mala_rotacion_billoflading
 select distinct b.CVE_BILL_OF_LADING,a.CVE_COMPRA_REC_DET,a.CVE_ALMACEN,a.CVE_PROVEEDOR,a.cve_proveedor_marca,a.NUM_CANTIDAD_INVENTARIO,a.cve_documento,a.dfecha_documento,a.CVE_ARTICULO_TIPO,a.cve_articulo,a.dfecha_manifiesto,null from tb_bi_mala_rotacion a
 inner join tb_bi_billoflading b on a.cve_billoflading = b.cve_id;

 update tb_mala_rotacion_billoflading a set cve_billoflading =  (Select first 1 cve_id from tb_bi_billoflading b where a.CVE_BILL_OF_LADING = b.CVE_BILL_OF_LADING);
suspend;
End

Go

execute procedure sp_bi_verifica_rotacion

Go

create table Tb_Bi_Inventarios_Hechos(
FEC_FECHA date,
CVE_TEMPORADA_ACTUAL integer,
CVE_TEMPORADA varchar(9),
CVE_SEMANA integer,
CVE_ANIO char(10),
CVE_MES varchar(10),
CVE_DIADELMES char(10),
CVE_DIADELASEMANA char(2),
CVE_TRANSCURRIDO integer,
CVE_ANIOMESDIA char(10),
CVE_MESDIA char(10),
CVE_DIAS integer,
CVE_ANALISIS INTEGER,
ID integer,
CVE_COMPRA_DET integer,
CVE_COMPRA_REC_DET integer,
CVE_INV_AJUSTE_DET integer,
CVE_PAGO_DET integer,
CVE_ALMACEN_LOCALIZ integer,
CVE_PROVEEDOR integer,
NUM_CANTIDAD_INVENTARIO numeric(18,12),
NUM_CANTIDAD_COMPRAS numeric(18,12),
NUM_CANTIDAD_VENTAS numeric(18,12),
MUN_CANTIDAD_DEVUELTA numeric(18,12),
MUN_CANTIDAD_COMPROMETIDA numeric(18,12),
NUM_DIAS_INVENTARIO integer,
NUM_CANTIDAD_DISPONIBLE numeric(18,4),
CVE_DOC_ID integer,
CVE_DOC_DET_ID integer,
CVE_DOC_TIPO varchar(11),
CVE_DOCUMENTO varchar(18),
DFECHA_DOCUMENTO date,
CVE_TIPO varchar(5),
CVE_ARTICULO_TIPO integer,
CVE_ARTICULO integer,
CVE_PROVEEDOR_MARCA integer,
CVE_CUENTA_VENTAS_ID integer,
CVE_CUENTA_INVENTARIO_ID integer,
CVE_CUENTA_COSTO_VENTAS_ID integer,
CVE_CUENTA_COMISION_ID integer,
NUM_COSTO numeric(18,4),
CVE_TIPOANALISIS integer,
DFECHA_MANIFIESTO date,
--CVE_STATUS INTEGER,
CVE_BILLOFLADING INTEGER,
CVE_PALLET VARCHAR(20),
CVE_CURRENT_DAY INTEGER
)

Go

create view VW_BI_CTL_PERIODOS_INVENTARIOS(
    CVE_TRANSCURRIDO,
    CVE_ANIO,
    CVE_MESDIA,
    CVE_DIADELMES)
as
select   
 distinct   
 cve_Transcurrido,  
 cve_Anio,
 cve_MesDia,  
 cve_DiaDelMes  
from Tb_Bi_Inventarios_Hechos

GO

insert into Tb_Bi_Inventarios_Hechos
select
cast(DFECHA_DOCUMENTO as date) as Fec_Fecha
,case
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))+1 as char(4)) from 3 for 2)
  then
  1
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  1
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))+1 as char(4)) from 3 for 2)
  then
  1
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  1

  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  2
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-2 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)
  then
  2
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  2
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-2 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)
  then
  2
  else
  3
  end as cve_Temporada_Actual
,case
        when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12)
    then substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)
        when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9)
    then substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)
 end as cve_Temporada
--,cast(((extract(yearday from cast(DFECHA_DOCUMENTO as date)) - extract(weekday from cast(DFECHA_DOCUMENTO as date)-1 ) + 7) / 7)as integer) as cve_Semana
,cast((Select cve_semana from tb_bi_semanas_normales x where DFECHA_DOCUMENTO between x.fechaini and x.fechafin) as integer) as cve_Semana
,case
 when cast(DFECHA_DOCUMENTO as date) < cast('1901-01-01' as date)
  then substring(cast(cast('1901-01-01' as date) as char(10))from 1 for 4)
 else
  substring(cast(cast(DFECHA_DOCUMENTO as date) as char(10))from 1 for 4)
  end as cve_Anio
,trim(substring(cast(cast(DFECHA_DOCUMENTO as date) as char(10))from 6 for 2)) as cve_Mes
,substring(cast(cast(DFECHA_DOCUMENTO as date) as char(10))from 9 for 2) as cve_DiaDelMes
,(case
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 1 then '01'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 2 then '02'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 3 then '03'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 4 then '04'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 5 then '05'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 6 then '06'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 0 then '07'
end) as cve_DiaDeLaSemana
,case 
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12)
   and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) > substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12)
   and extract(month from cast(current_date as date)) in (10,11,12)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) < substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9)
   and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) < substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9)
   and extract(month from cast(current_date as date)) in (10,11,12)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) > substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   else
                                                                   2 
end as cve_Transcurrido,
case
 when cast(DFECHA_DOCUMENTO as date) < cast('1901-01-01' as date)
  then cast(cast('1901-01-01' as date) as char(10))
   else
  cast(cast(DFECHA_DOCUMENTO as date) as char(10))
  end as cve_AnioMesDia,
substring(cast(cast(DFECHA_DOCUMENTO as date)as char(10))from 6 for 10) as cve_MesDia,
case
    when num_dias_inventario = 0 then 1
    when num_dias_inventario = 1 then 2
    when num_dias_inventario = 2 then 3
    when num_dias_inventario = 3 then 4
    when num_dias_inventario = 4 then 5
    when num_dias_inventario = 5 then 6
    when num_dias_inventario = 6 then 7
    when num_dias_inventario = 7 then 8
    when num_dias_inventario > 7 and num_dias_inventario < 13 then 9
    when num_dias_inventario > 12 then 10
end cve_dias,
X.*
from
(
select
1 as cve_analisis,
f.*,
--0 as satatus,
0 as cve_billoflading,
cast(('R'||CVE_COMPRA_REC_DET) as varchar(20)) as cve_pallet,
0 as Current_day
from  tb_bi_fuente_inventario  f

 Union all

Select distinct
2 as cve_Analisis,
0 as ID,
0 as CVE_COMPRA_DET,
CVE_COMPRA_REC_DET,
0 as CVE_INV_AJUSTE_DET,
0 as CVE_PAGO_DET,
CVE_ALMACEN,
CVE_PROVEEDOR,
NUM_CANTIDAD_INVENTARIO,
0.00 as NUM_CANTIDAD_COMPRAS,
0.00 as NUM_CANTIDAD_VENTAS,
0.00 as MUN_CANTIDAD_DEVUELTA,
0.00 as MUN_CANTIDAD_COMPROMETIDA,
0 as NUM_DIAS_INVENTARIO,
0.00 as NUM_CANTIDAD_DISPONIBLE,
0 as CVE_DOC_ID,
0 as CVE_DOC_DET_ID,
0 as CVE_DOC_TIPO,
CVE_DOCUMENTO,
DFECHA_DOCUMENTO,
'INV' CVE_TIPO,
CVE_ARTICULO_TIPO,
CVE_ARTICULO,
CVE_PROVEEDOR_MARCA as CVE_PROVEEDOR_MARCA,
0 as CVE_CUENTA_VENTAS_ID,
0 as CVE_CUENTA_INVENTARIO_ID,
0 as CVE_CUENTA_COSTO_VENTAS_ID,
0 as CVE_CUENTA_COMISION_ID,
0 as NUM_COSTO,
1 as CVE_TIPOANALISIS,
dfecha_manifiesto,
--status cve_status,
0,--cve_billoflading,
cast(('R'||CVE_COMPRA_REC_DET) as varchar(20)) as cve_pallet,
case
  when DFECHA_DOCUMENTO = (Current_Date -1) then
  1
  when DFECHA_DOCUMENTO = (Current_Date -2) then
  2
  else
  0
end as Current_day
from tb_mala_rotacion_billoflading

UNION all

Select distinct
3 as cve_Analisis,
0 as ID,
0 as CVE_COMPRA_DET,
CVE_COMPRA_REC_DET,
0 as CVE_INV_AJUSTE_DET,
0 as CVE_PAGO_DET,
CVE_ALMACEN,
CVE_PROVEEDOR,
NUM_CANTIDAD_INVENTARIO,
0.00 as NUM_CANTIDAD_COMPRAS,
0.00 as NUM_CANTIDAD_VENTAS,
0.00 as MUN_CANTIDAD_DEVUELTA,
0.00 as MUN_CANTIDAD_COMPROMETIDA,
0 as NUM_DIAS_INVENTARIO,
0.00 as NUM_CANTIDAD_DISPONIBLE,
0 as CVE_DOC_ID,
0 as CVE_DOC_DET_ID,
0 as CVE_DOC_TIPO,
CVE_DOCUMENTO,
DFECHA_DOCUMENTO,
'INV' CVE_TIPO,
CVE_ARTICULO_TIPO,
CVE_ARTICULO,
CVE_PROVEEDOR_MARCA as CVE_PROVEEDOR_MARCA,
0 as CVE_CUENTA_VENTAS_ID,
0 as CVE_CUENTA_INVENTARIO_ID,
0 as CVE_CUENTA_COSTO_VENTAS_ID,
0 as CVE_CUENTA_COMISION_ID,
0 as NUM_COSTO,
1 as CVE_TIPOANALISIS,
dfecha_manifiesto,
--status cve_status,
cve_billoflading,
cast(('R'||CVE_COMPRA_REC_DET) as varchar(20)) as cve_pallet,
case
  when DFECHA_DOCUMENTO = (Current_Date -1) then
  1
  when DFECHA_DOCUMENTO = (Current_Date -2) then
  2
  else
  0
end as Current_day
from tb_mala_rotacion_billoflading

union all

Select
4 as cve_Analisis,
0 as ID,
0 as CVE_COMPRA_DET,
ompra_rec_det_id CVE_COMPRA_REC_DET,
0 as CVE_INV_AJUSTE_DET,
0 as CVE_PAGO_DET,
a.ALMACEN_LOCALIZ_ID as CVE_ALMACEN_LOCALIZ,
a.proveedor_id as CVE_PROVEEDOR,
cant_inventario as NUM_CANTIDAD_INVENTARIO,
0.00 as NUM_CANTIDAD_COMPRAS,
0.00 as NUM_CANTIDAD_VENTAS,
0.00 as MUN_CANTIDAD_DEVUELTA,
0.00 as MUN_CANTIDAD_COMPROMETIDA,
0 as NUM_DIAS_INVENTARIO,
0.00 as NUM_CANTIDAD_DISPONIBLE,
0 as CVE_DOC_ID,
0 as CVE_DOC_DET_ID,
0 as CVE_DOC_TIPO,
(select * from sp_bi_origen_referencia(OMPRA_REC_DET_ID)) as CVE_DOCUMENTO,
fecha_inventario as DFECHA_DOCUMENTO,
'INV' CVE_TIPO,
h.articulo_tipo_id as CVE_ARTICULO_TIPO,
g.articulo_id as CVE_ARTICULO,
g.proveedor_marca_id as CVE_PROVEEDOR_MARCA,
0 as CVE_CUENTA_VENTAS_ID,
0 as CVE_CUENTA_INVENTARIO_ID,
0 as CVE_CUENTA_COSTO_VENTAS_ID,
0 as CVE_CUENTA_COMISION_ID,
0 as NUM_COSTO,
1 as CVE_TIPOANALISIS,
cast(coalesce(cast(f.fecha_recibo as date),'10-01-1901') as date) as dfecha_manifiesto,
--0 as cve_status,
0 as cve_billoflading,
'0' as cve_pallet,
0 as Current_day
from tb_bi_historico_inventario a
inner join tb_compras_rec_det b on a.ompra_rec_det_id=b.id
left join tb_compras_rec f on b.compra_rec_id = f.id
inner join tb_compras_det g on a.compra_det_id = g.id
inner join tb_c_Articulos h on g.articulo_id = h.id
where a.cant_inventario <>0 and a.fecha_inventario >= (case
    when(extract(month from current_date) in (10,11,12))then
       cast(cast(extract(year from current_date)-2 as varchar(4)) || '-10-01' as date)
    when (extract(month from current_date) in (1,2,3,4,5,6,7,8,9))then
       cast(cast(extract(year from current_date)-3 as varchar(4)) || '-10-01' as date)
end)
) as X

Go

CREATE PROCEDURE SP_REP_COMPRA_DEV_BI (
    fecha_inicio date,
    fecha_fin date)
returns (
    dfecha_documento date,
    compra_dev_det_id integer,
    proveedor_id integer,
    cant_devuelta numeric(18,4),
    cant_recibida numeric(18,4),
    tipo varchar(5),
    doc_tipo varchar(1),
    doc_no varchar(18),
    doc_fecha date,
    doc_det_id integer,
    doc_id integer,
    articulo_id integer,
    proveedor_marca_id integer,
    almacen_localiz_id integer,
    orden_devolucion varchar(18),
    fecha_devolucion date,
    nota varchar(40))
as
declare variable compra_dev_id integer;
declare variable compra_rec_id integer;
declare variable compra_rec_det_id integer;
begin
  -- localiza lo enviado a reempaque
  for select a.fecha_devolucion,a.id, b.id,
  b.cant_devuelta, b.nota,
  c.tipo, c.doc_tipo, c.doc_no, c.doc_fecha, c.doc_det_id, c.doc_id,
  c.articulo_id, c.proveedor_marca_id, b.almacen_localiz_id,
  a.orden_devolucion, a.fecha_devolucion, c.proveedor_id

  from tb_compras_dev a left join tb_compras_dev_det b
  on a.id=b.compra_dev_id
  left join sp_inventario_info2(null, null, b.compra_det_id, b.compra_rec_det_id,b.inv_ajuste_det_id, b.pago_det_id) c
  on 1=1
  where a.fecha_devolucion between :fecha_inicio and :fecha_fin
  into :dfecha_documento, :compra_dev_id, :compra_dev_det_id,
  :cant_devuelta, :nota,
  :tipo, :doc_tipo, :doc_no, :doc_fecha, :doc_det_id, :doc_id,
  :articulo_id, :proveedor_marca_id, :almacen_localiz_id,
  :orden_devolucion, :fecha_devolucion, :proveedor_id
  do begin
    suspend;
  end

  cant_devuelta=0;

  -- articulos recibidos
  for select  cast(b.fecha_recibo as date),a.compra_dev_det_id, a.cant_recibida,
  a.articulo_id, a.proveedor_marca_id, a.almacen_localiz_id,
  b.id, b.referencia,
  c.tipo, c.doc_tipo, c.doc_no, c.doc_fecha, c.doc_det_id, c.doc_id,
  c.articulo_id, c.proveedor_marca_id, c.proveedor_id
  from tb_compras_rec_det a left join tb_compras_rec b
  on a.compra_rec_id=b.id
  left join sp_inventario_info2(a.articulo_id, a.proveedor_marca_id, a.compra_det_id, a.id,
    null, null) c
  on 1=1
  where b.recibo_tipo='DEVOLUCION' and cast(b.fecha_recibo as date) between :fecha_inicio and :fecha_fin
  into :dfecha_documento, :compra_dev_det_id, :cant_recibida,
  :articulo_id, :proveedor_marca_id, :almacen_localiz_id,
  :compra_rec_id, :orden_devolucion,
  :tipo, :doc_tipo, :doc_no, :doc_fecha, :doc_det_id, :doc_id,
  :articulo_id, :proveedor_marca_id, :proveedor_id
  do begin
    if (doc_tipo is null) then
    begin
       tipo='CAT';
       doc_tipo='R';
       doc_no=orden_devolucion;
       doc_fecha=fecha_devolucion;
       doc_id=compra_rec_id;
       doc_det_id=compra_rec_det_id;

    end
    suspend;
  end
end


Go

alter table tb_bi_inventarios_hechos
add NUM_SENT NUMERIC(18,4)

Go

alter table tb_bi_inventarios_hechos
add NUM_RECEIVED NUMERIC(18,4)

Go

alter table tb_bi_inventarios_hechos
add cve_TipoRepack INT

Go

update tb_bi_inventarios_hechos set NUM_SENT=0.00,NUM_RECEIVED=0.00,cve_TipoRepack = 0

Go

insert into tb_bi_inventarios_hechos
select
cast(DFECHA_DOCUMENTO as date) as Fec_Fecha
,case
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))+1 as char(4)) from 3 for 2)
  then
  1
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  1
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))+1 as char(4)) from 3 for 2)
  then
  1
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  1

  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  2
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-2 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)
  then
  2
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (10,11,12) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date)) as char(4)) from 3 for 2)
  then
  2
  when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9) and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9) and
  substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)=
  substring(cast(extract(year from cast(current_date as date))-2 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(current_date as date))-1 as char(4)) from 3 for 2)
  then
  2
  else
  3
  end as cve_Temporada_Actual
,case
        when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12)
    then substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))+1 as char(4)) from 3 for 2)
        when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9)
    then substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date))-1 as char(4)) from 3 for 2)||'-'||substring(cast(extract(year from cast(DFECHA_DOCUMENTO as date)) as char(4)) from 3 for 2)
 end as cve_Temporada
--,cast(((extract(yearday from cast(DFECHA_DOCUMENTO as date)) - extract(weekday from cast(DFECHA_DOCUMENTO as date)-1 ) + 7) / 7)as integer) as cve_Semana
,cast((Select cve_semana from tb_bi_semanas_normales x where DFECHA_DOCUMENTO between x.fechaini and x.fechafin) as integer) as cve_Semana
,case
 when cast(DFECHA_DOCUMENTO as date) < cast('1901-01-01' as date)
  then substring(cast(cast('1901-01-01' as date) as char(10))from 1 for 4)
 else
  substring(cast(cast(DFECHA_DOCUMENTO as date) as char(10))from 1 for 4)
  end as cve_Anio
,trim(substring(cast(cast(DFECHA_DOCUMENTO as date) as char(10))from 6 for 2)) as cve_Mes
,substring(cast(cast(DFECHA_DOCUMENTO as date) as char(10))from 9 for 2) as cve_DiaDelMes
,(case
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 1 then '01'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 2 then '02'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 3 then '03'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 4 then '04'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 5 then '05'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 6 then '06'
  when extract(weekday from cast(DFECHA_DOCUMENTO as date)) = 0 then '07'
end) as cve_DiaDeLaSemana
,case 
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12)
   and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) > substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (10,11,12)
   and extract(month from cast(current_date as date)) in (10,11,12)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) < substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9)
   and extract(month from cast(current_date as date)) in (1,2,3,4,5,6,7,8,9)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) < substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   when extract(month from cast(DFECHA_DOCUMENTO as date)) in (1,2,3,4,5,6,7,8,9)
   and extract(month from cast(current_date as date)) in (10,11,12)
   and substring(cast(DFECHA_DOCUMENTO as date)from 6 for 6) > substring(cast(current_date as date)from 6 for 6)
   then
                                                                   1
   else
                                                                   2 
end as cve_Transcurrido,
case
 when cast(DFECHA_DOCUMENTO as date) < cast('1901-01-01' as date)
  then cast(cast('1901-01-01' as date) as char(10))
   else
  cast(cast(DFECHA_DOCUMENTO as date) as char(10))
  end as cve_AnioMesDia,
substring(cast(cast(DFECHA_DOCUMENTO as date)as char(10))from 6 for 10) as cve_MesDia,
/*case
    when num_dias_inventario = 0 then 1
    when num_dias_inventario = 1 then 2
    when num_dias_inventario = 2 then 3
    when num_dias_inventario = 3 then 4
    when num_dias_inventario = 4 then 5
    when num_dias_inventario = 5 then 6
    when num_dias_inventario = 6 then 7
    when num_dias_inventario = 7 then 8
    when num_dias_inventario > 7 and num_dias_inventario < 13 then 9
    when num_dias_inventario > 12 then 10
end */ 0 as cve_dias,
X.*
from
(
select
5 as CVE_ANALISIS,
a.compra_dev_det_id as ID,
a.compra_dev_det_id as CVE_COMPRA_DET,
a.compra_dev_det_id as CVE_COMPRA_REC_DET,
0 as CVE_INV_AJUSTE_DET,
0 as CVE_PAGO_DET,
0 as CVE_ALMACEN_LOCALIZ,
a.PROVEEDOR_ID as CVE_PROVEEDOR,
0.00 as  NUM_CANTIDAD_INVENTARIO,
0.00 as  NUM_CANTIDAD_COMPRAS,
0.00 as  NUM_CANTIDAD_VENTAS,
0.00 as  MUN_CANTIDAD_DEVUELTA,
0.00 as  MUN_CANTIDAD_COMPROMETIDA,
0.00 as  NUM_DIAS_INVENTARIO,
0.00 as  NUM_CANTIDAD_DISPONIBLE,
0 as CVE_DOC_ID,
0 as CVE_DOC_DET_ID,
null as CVE_DOC_TIPO,
a.DOC_NO as CVE_DOCUMENTO,
a.DFECHA_DOCUMENTO,
--a.DOC_FECHA as DFECHA_DOCUMENTO1,
null as CVE_TIPO,
(Select CVE_ARTICULO_TIPO from vw_bi_ctl_articulos Z where Z.cve_articulo = a.articulo_id) AS CVE_ARTICULO_TIPO,
a.articulo_id as CVE_ARTICULO,
coalesce(a.proveedor_marca_id,0) as CVE_PROVEEDOR_MARCA,
0 as CVE_CUENTA_VENTAS_ID,
0 as CVE_CUENTA_INVENTARIO_ID,
0 as CVE_CUENTA_COSTO_VENTAS_ID,
0 as CVE_CUENTA_COMISION_ID,
0.0 as NUM_COSTO,
1 as CVE_TIPOANALISIS,
a.doc_fecha as DFECHA_MANIFIESTO,
0 as CVE_BILLOFLADING,
'0' as CVE_PALLET,
case
  when DFECHA_DOCUMENTO = (Current_Date -1) then
  1
  when DFECHA_DOCUMENTO = (Current_Date -2) then
  2
  else
  0
end as CVE_CURRENT_DAY,

coalesce(a.CANT_DEVUELTA,0.00) as num_Sent,
coalesce(a.CANT_RECIBIDA,0.00) as num_Received,

case
    when coalesce(a.CANT_DEVUELTA,0.00) > 0 then 1
    when h.des_proveedor_marca like '%WHOLE TRADE%' then 2
    when h.des_proveedor_marca like '%FAIR TRADE%' then 3
    when c.nombre not like '%#2%' and  c.nombre not like '%BULK%'  and h.des_proveedor_marca not like '%FAIR TRADE%' and h.des_proveedor_marca not like '%WHOLE TRADE%'  and c.descripcion not like '%CHOPPER%' then 4
    when c.nombre  like '%#2%'         then 5
    when c.nombre  like '%BULK%'       then 6
    when c.descripcion like '%CHOPPER%' then 7
    else 0
 end as cve_TipoRepack
    

 /*
'======' as SEPARACION,


a.*,
b.nombre as proveedor_marca_nombre,
b.descripcion as proveedor_marca_descripcion,
c.nombre as articulo_nombre,
c.descripcion as articulo_descripcion,
c.numero_2,
e.nombre as almacen_nombre,
e.descripcion as almacen_descripcion,
coalesce(a.compra_dev_det_id, 0) || c.nombre as grupo_1,
f.nombre as proveedor_nombre,
f.descripcion as proveedor_descripcion,
c.indice_sorteo as articulo_indice,
g.indice_sorteo as tipo_indice_sorteo,
c.descripcion || b.descripcion as articulo_marca,
g.nombre as tipo_nombre */

from SP_REP_COMPRA_DEV_BI ((select  cast( '10-01-'||(select cast(extract (year from current_date)-2 as char(4)) from new_table)as date) from new_table),(select (current_date) from new_table)) a --(:fecha_inicio, :fecha_fin) a
left join tb_c_proveedores_marcas b
on a.proveedor_marca_id=b.id
left join tb_c_articulos c
on a.articulo_id=c.id
left join tb_c_almacenes_localiz d
on a.almacen_localiz_id=d.id
left join tb_c_almacenes e
on d.almacen_id=e.id
left join tb_c_proveedores f
on a.proveedor_id=f.id
left join tb_c_articulos_tipos g
on c.articulo_tipo_id=g.id
left join vw_bi_ctl_proveedoresmarcas h
on a.proveedor_marca_id = h.cve_proveedor_marca
--where (a.proveedor_id=:proveedor_id) or (cast(:proveedor_id as integer) is null )
order by c.numero_2, g.nombre, c.descripcion, b.descripcion, c.indice_sorteo, g.indice_sorteo
) as x

Go

Create table  tb_bi_semanas_Normal(
cve_Temporada varchar(5),
cve_mes varchar(2),
cve_Semana_Normal varchar(2),
cve_Quincena integer,
cve_semana integer,
fec_ini date,
fec_fin date
)

Go

insert into  tb_bi_semanas_Normal
select '04-05' as cve_Temporada,'01' as cve_mes,'01' as cve_semana_Normal,1 as cve_Quincena,1 as cve_semana,cast('2005-01-01' as date) as fec_ini,cast('2005-01-07' as date)as fec_fin  from new_table;

Go

create procedure  sp_bi_semanas_Normal(
fecha date)
as
 declare variable dfecha date;
 declare variable fecha_tope date;
 declare variable Semana_Normal integer;
 declare variable Quincena integer;
 declare variable Semana integer;

 begin
  select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc
  into :fecha_tope;
  dfecha = :fecha;
  Semana_Normal = 1;
  Quincena = 1;
  Semana = 2;

  while (:fecha_tope < :dfecha )do
  begin
   if (:Semana_Normal >= 52 )then
   Semana_Normal = 0;
   else if (:Semana_Normal >= 52 )then
   Quincena = 1;
   else if (:Semana_Normal >= 52 )then
   Semana =1;
   else

    while(:Quincena <= 2)do
    begin
     While(:Semana <= 2)do
     begin
     Semana_Normal = :Semana_Normal + 1;

     insert into tb_bi_semanas_Normal
     Select
      case
       when extract(month from (cast((select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1 as date))) in (10,11,12) then
        substring(cast(extract (year from (cast((select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1 as date)))as char(4)) from  3 for 2)||'-'||substring(extract(year from (cast((select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1 as date)))+1 from  3 for 2)

       when extract (month from (cast((select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1 as date))) in (1,2,3,4,5,6,7,8,9) then
        substring(cast(extract(year from (cast((select first 1 fec_fin from tb_bi_semanas_Normal Salary order by fec_fin desc)+1 as date)))-1 as char(4)) from  3 for 2)||'-'||substring(extract (year from (cast((select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1 as date))) from  3 for 2)
      end as cve_Temporada
      ,cast(extract(month from ((select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1)) as varchar(2))as cve_mes
      ,case
        when ((select char_length(:Semana_Normal) from new_table) in (1))then
        (select cast('0'||:Semana_Normal as char(2)) from new_table)
        else
         (select cast(:Semana_Normal as char(2)) from new_table)
      end as cve_Semana_Agricola
      ,:Quincena as cve_Quincena
      ,:Semana as cve_Semana
      ,(select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc)+1 as fec_ini
      ,(select first 1 fec_fin from tb_bi_semanas_Normal  order by fec_fin desc)+7 as fec_fin
     from new_table;

     Semana = :Semana + 1;
     end
     Quincena = :Quincena + 1;
     semana = 1;
    end
    Quincena = 1;
    Semana = 1;
    select first 1 fec_fin from tb_bi_semanas_Normal order by fec_fin desc
    into :fecha_tope;
 end
 suspend;
End

Go

EXECUTE PROCEDURE sp_bi_semanas_Normal ('12-31-2020')

Go

alter table Tb_Bi_Inventarios_Hechos
ADD CVE_SEMANA_INVENTARIO integer

Go

update Tb_Bi_Inventarios_Hechos set CVE_SEMANA_INVENTARIO = (Select first 1 x.CVE_SEMANA_NORMAL from  tb_bi_semanas_normal x where fec_fecha between x.fec_ini and x.fec_fin)

Go