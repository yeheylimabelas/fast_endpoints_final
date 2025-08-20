// -----------------------------------------------------------------------------------
// JobPlant.cs 2024
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
    /// FilterJobsByRoleAndPlantArea
    /// </summary>
    /// <param name="_auth"></param>
    /// <param name="_attributes"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<Expression<Func<Job, bool>>> FilterJobsByRoleAndPlantArea(
        this IUserAuthorizationService _auth,
        Dictionary<string, List<string>> _attributes,
        CancellationToken cancellationToken = default)
    {
        var user = _auth.GetAuthorizedUser();

        _attributes ??= await _auth.GetUserAttributesAsync(cancellationToken).ConfigureAwait(false);
        var customers = _attributes.GetAttribute(UserAttributeConstants.CustomerName);

        var plants = new List<string>();

        if (_attributes.TryGetValue(UserAttributeConstants.PlantFieldName, out var attribute))
        {
            plants = attribute.Distinct().ToList();
        }

        var predicateJobs = PredicateBuilderExtensions.True<Job>();
        var isCustomerCheck = false;

        if (!string.IsNullOrEmpty(user.CustomerCode) && !user.CustomerCode.Equals(UserAttributeConstants.All))
        {
            predicateJobs = predicateJobs.And(x => x.Customer.Code.ToLower().Equals(user.CustomerCode.NullSafeToLower()));
            isCustomerCheck = true;
        }

        if (customers.Count > 0 && !customers.Contains(UserAttributeConstants.All))
        {
            predicateJobs = isCustomerCheck ?
                predicateJobs.Or(x => customers.Contains(x.Customer.Code)) :
                predicateJobs.And(x => customers.Contains(x.Customer.Code));
        }

        if (plants.FirstOrDefault() != UserAttributeConstants.All)
        {
            predicateJobs = predicateJobs.And(x => plants.Contains(x.PlantArea));
        }

        return predicateJobs;
    }
}
