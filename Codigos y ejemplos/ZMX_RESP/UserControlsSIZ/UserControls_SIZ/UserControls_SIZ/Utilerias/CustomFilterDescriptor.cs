using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Data;

namespace UserControlsSIZ.Utilerias
{
    public class CustomFilterDescriptor : FilterDescriptorBase
    {
        private readonly CompositeFilterDescriptor compositeFilterDescriptor;
        private static readonly ConstantExpression TrueExpression = System.Linq.Expressions.Expression.Constant(true);
        private string filterValue;
        public RadGridView grid;

        public CustomFilterDescriptor(IEnumerable<Telerik.Windows.Controls.GridViewColumn> columns)
        {
            this.compositeFilterDescriptor = new CompositeFilterDescriptor();
            this.compositeFilterDescriptor.LogicalOperator = FilterCompositionLogicalOperator.Or;

            foreach (Telerik.Windows.Controls.GridViewColumn column in columns)
            {
                if (column is GridViewDataColumn)
                {
                    if (column.IsVisible)
                        this.compositeFilterDescriptor.FilterDescriptors.Add(this.CreateFilterForColumn((GridViewDataColumn)column));
                }
            }
        }

        public string FilterValue
        {
            get
            {
                return this.filterValue;
            }
            set
            {
                if (this.filterValue != value)
                {
                    this.filterValue = value;
                    this.UpdateCompositeFilterValues();
                    this.OnPropertyChanged("FilterValue");
                }
            }
        }

        protected override System.Linq.Expressions.Expression CreateFilterExpression(ParameterExpression parameterExpression)
        {
            if (string.IsNullOrEmpty(this.FilterValue))
            {
                return TrueExpression;
            }
            try
            {
                return this.compositeFilterDescriptor.CreateFilterExpression(parameterExpression);
            }
            catch
            {
            }

            return TrueExpression;
        }

        private bool filtro(object obj, string prop)
        {
            GridViewDataColumn column = grid.Columns[prop] as GridViewDataColumn;
            var converter = column.DataMemberBinding?.Converter;
            string valor = null;

            if (obj is DataRowView)
            {
                valor = ((DataRowView)obj)[prop].ToString();
            }
            else if (obj is DataRow)
            {
                valor = ((DataRow)obj)[prop].ToString();
            }
            else
            {
                valor = obj.GetType().GetProperty(prop).GetValue(obj).ToString();
            }

            if (converter != null)
            {
                valor = converter.Convert(valor, null, null, null)?.ToString();
            }

            return valor.ToLower().Contains(this.filterValue.ToLower());
        }

        private IFilterDescriptor CreateFilterForColumn(GridViewDataColumn column)
        {

            FilterOperator filterOperator = GetFilterOperatorForType(column.DataType);

            if (column.DataType == typeof(short) || column.DataType == typeof(int) || column.DataType == typeof(long)
                || column.DataType == typeof(short?) || column.DataType == typeof(int?) || column.DataType == typeof(long?))
            {
                var descriptorG = new FilterDescriptor<GridViewRow>();
                string cName = column.UniqueName;
                descriptorG.FilteringExpression = x => filtro(x, cName);

                return descriptorG;
            }
            else
            {
                var descriptorN = new FilterDescriptor(column.UniqueName, filterOperator, this.filterValue);
                descriptorN.MemberType = column.DataType;

                return descriptorN;
            }
        }

        private static FilterOperator GetFilterOperatorForType(Type dataType)
        {
            return dataType == typeof(string) ? FilterOperator.Contains : FilterOperator.IsEqualTo;
        }

        private void UpdateCompositeFilterValues()
        {
            foreach (var d in this.compositeFilterDescriptor.FilterDescriptors)
            {
                if (d is FilterDescriptor)
                {
                    var descriptor = d as FilterDescriptor;
                    object convertedValue = DefaultValue(descriptor.MemberType);

                    try
                    {
                        var tipo = Nullable.GetUnderlyingType(descriptor.MemberType);
                        convertedValue = Convert.ChangeType(this.FilterValue, tipo ?? descriptor.MemberType, CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        convertedValue = Telerik.Windows.Data.FilterDescriptor.UnsetValue;
                    }

                    if (descriptor.MemberType != null && descriptor.MemberType.IsAssignableFrom(typeof(DateTime)))
                    {
                        DateTime date;
                        if (DateTime.TryParse(this.FilterValue, out date))
                        {
                            convertedValue = date;
                        }
                    }

                    descriptor.Value = convertedValue;
                }
            }
        }

        private static object DefaultValue(Type type)
        {
            if (type != null && type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}
