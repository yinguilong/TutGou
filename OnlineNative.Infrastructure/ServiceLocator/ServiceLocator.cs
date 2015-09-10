/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Infrastructure.ServiceLocator
 *文件名：  ServiceLocator
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/2/2015 9:50:17 AM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/2/2015 9:50:17 AM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Reflection;

namespace OnlineNative.Infrastructure
{
    public class ServiceLocator : IServiceProvider
    {
        private readonly IUnityContainer _container;
        private static ServiceLocator _instance = new ServiceLocator();

        private ServiceLocator()
        {
            _container = new UnityContainer();
            try
            {
                UnityConfigurationSection configuration = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
                configuration.Configure(_container, "defaultContainer");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static ServiceLocator Instance
        {
            get { return _instance; }
        }

        #region Public Methods

        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }

        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }

        public void Register<TFrom, TTo>(string name) where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>(name);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        public T GetService<T>(object overridedArguments)
        {
            var overrides = GetParameterOverrides(overridedArguments);
            return _container.Resolve<T>(overrides.ToArray());
        }

        public object GetService(Type serviceType, object overridedArguments)
        {
            var overrides = GetParameterOverrides(overridedArguments);
            return _container.Resolve(serviceType, overrides.ToArray());
        }

        #endregion

        #region Private Methods
        private IEnumerable<ParameterOverride> GetParameterOverrides(object overridedArguments)
        {
            var overrides = new List<ParameterOverride>();
            var argumentsType = overridedArguments.GetType();
            argumentsType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToList()
                .ForEach(property =>
                {
                    var propertyValue = property.GetValue(overridedArguments, null);
                    var propertyName = property.Name;
                    overrides.Add(new ParameterOverride(propertyName, propertyValue));
                });
            return overrides;
        }
        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        #endregion
    }
}
