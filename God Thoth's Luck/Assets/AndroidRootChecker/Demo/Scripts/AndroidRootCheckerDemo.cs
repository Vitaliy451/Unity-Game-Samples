using UnityEngine;
using UnityEngine.UI;

public class AndroidRootCheckerDemo : MonoBehaviour
{
	public Text Packages;
	public string PackagesFormat = "Root packages found: {0}";
	public Text Files;
	public string FilesFormat = "Root files found: {0}";
	public Text Binaries;
	public string BinariesFormat = "Root binaries found: {0}";
	public Text DangerousProps;
	public string DangerousPropsFormat = "Root dangerous props found: {0}";
	public Text ReadWritePaths;
	public string ReadWritePathsFormat = "Root read/write paths found: {0}";
	public Text TestKeys;
	public string TestKeysFormat = "Root test keys found: {0}";
	public Text CommandsExists;
	public string CommandsExistsFormat = "Root commands found: {0}";
	public Text Result;
	public string ResultFormat = "Device is {0}rooted";

	private const string IsNotRooted = "not ";
	private const string Positive = "Yes";
	private const string Negative = "No";
	
	void Awake()
	{
		Packages.text = string.Format(PackagesFormat, AndroidRootChecker.CheckPackages() ? Positive : Negative);
		Files.text = string.Format(FilesFormat, AndroidRootChecker.CheckFiles() ? Positive : Negative);
		Binaries.text = string.Format(BinariesFormat, AndroidRootChecker.CheckBinaries() ? Positive : Negative);
		DangerousProps.text = string.Format(DangerousPropsFormat, AndroidRootChecker.CheckDangerousProps() ? Positive : Negative);
		ReadWritePaths.text = string.Format(ReadWritePathsFormat, AndroidRootChecker.CheckReadWritePaths() ? Positive : Negative);
		TestKeys.text = string.Format(TestKeysFormat, AndroidRootChecker.CheckTestKeys() ? Positive : Negative);
		CommandsExists.text = string.Format(CommandsExistsFormat, AndroidRootChecker.CheckCommandsExists() ? Positive : Negative);
		Result.text = string.Format(ResultFormat, AndroidRootChecker.IsRooted() ? string.Empty : IsNotRooted);
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}