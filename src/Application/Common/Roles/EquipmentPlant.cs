// -----------------------------------------------------------------------------------
// EquipmentPlant.cs 2024
// Copyright DAD RnD. All rights reserved.
// DAD Helpdesk (helpdesk.mobweb@unitedtractors.com)
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MSCoip.Application.Common.Extensions;
using MSCoip.Application.Common.Interfaces;
using MSCoip.Domain.Constants;

namespace MSCoip.Application.Common.Roles;

/// <summary>
/// EntityRoleExtensions
/// </summary>
public static partial class EntityRoleExtensions
{
    /// <summary>
    /// FilterEquipmentsByRoleAndPlantArea
    /// </summary>
    /// <param name="auth"></param>
    /// <param name="attributes"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Expression<Func<Equipment, bool>>> FilterEquipmentsByRoleAndPlantArea(
        this IUserAuthorizationService auth,
        Dictionary<string, List<string>> attributes,
        CancellationToken cancellationToken = default)
    {
        var user = auth.GetAuthorizedUser();

        attributes ??= await auth.GetUserAttributesAsync(cancellationToken).ConfigureAwait(false);
        var customers = attributes.GetAttribute(UserAttributeConstants.CustomerCode);

        var plants = new List<string>();

        if (attributes.TryGetValue(UserAttributeConstants.PlantFieldName, out var attribute))
        {
            plants = attribute.Distinct().ToList();
        }

        var predicateCustomers = PredicateBuilderExtensions.True<Equipment>();
        var isCustomerCheck = false;

        if (!string.IsNullOrEmpty(user.CustomerCode) && !user.CustomerCode.Equals(UserAttributeConstants.All))
        {
            predicateCustomers = predicateCustomers.And(x => x.CustomerCode.ToLower().Equals(user.CustomerCode.NullSafeToLower()));
            isCustomerCheck = true;
        }

        if (customers.Count > 0 && !customers.Contains(UserAttributeConstants.All))
        {
            predicateCustomers = isCustomerCheck ?
                predicateCustomers.Or(x => customers.Contains(x.CustomerCode)) :
                predicateCustomers.And(x => customers.Contains(x.CustomerCode));
        }

        if (plants.FirstOrDefault() != UserAttributeConstants.All)
        {
            predicateCustomers = predicateCustomers.And(x => plants.Contains(x.PlantCode));
        }

        return predicateCustomers;
    }
}
