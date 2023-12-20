using Business_Layer.IServices;
using DataAccessLayer.data;
using DataAccessLayer.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SeedAdmin : ControllerBase
{
	private readonly ISeedAdminService _seedAdminService;

	public SeedAdmin(ISeedAdminService seedAdminService)
	{
		_seedAdminService = seedAdminService;
	}

	[HttpPost("seed/admin")]
	public async Task<IActionResult> SeedAdminUser()
	{
		var adminSeeded = await _seedAdminService.SeedAdminUser();
		if (adminSeeded)
		{
			return Ok("Admin user seeded successfully");
		}
		else
		{
			return Ok("Admin user already exists");
		}
	}

}
