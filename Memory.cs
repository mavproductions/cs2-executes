using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory.DynamicFunctions;

namespace ExecutesPlugin.Memory;

public static class GrenadeFunctions
{
	public static MemoryFunctionWithReturn<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, CSmokeGrenadeProjectile> CSmokeGrenadeProjectile_CreateFunc = new(
			Environment.OSVersion.Platform == PlatformID.Unix 
				? @"\x55\x4C\x89\xC1\x48\x89\xE5\x41\x57\x41\x56\x49\x89\xD6"
				: @"\x48\x89\x5C\x24\x2A\x48\x89\x6C\x24\x2A\x48\x89\x74\x24\x2A\x57\x41\x56\x41\x57\x48\x83\xEC\x50\x4C\x8B\xB4\x24"
	);

	public static MemoryFunctionWithReturn<string, float, float, int> EmitSound = new(@"\x55\x48\x89\xe5\x41\x57\x41\x56\x41\x55\x41\x54\x53\x48\x81\xec\xa8\x00\x00\x00\x48\x85\xd2\x74\x08\x80\x3a\x00\x48\x89\xd3\x75\x1f\x49\xbc\x00\x00\x00\x00\xff\xff\xff\xff");
}