using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Permissions
{
    using System.Threading.Tasks;

    using AER.Enigma.Models.Permissions;

    public interface IPermissionsService
    {
        Task<PermissionStatus> CheckPermissionStatusAsync(Permission permission);
        Task<Dictionary<Permission, PermissionStatus>> RequestPermissionsAsync(params Permission[] permissions);
    }
}
