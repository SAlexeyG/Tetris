using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
	[SerializeField] private float fallTime = default;
	[SerializeField] private GameObject[] tetrominos = default;
	[SerializeField] private Vector3 spawnPoint = default;
	[SerializeField] private int fieldHeight = default;
	[SerializeField] private int fieldWidth = default;

    public override void InstallBindings()
    {
		Container.Bind<float>().FromInstance(fallTime).NonLazy();
		Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();

		Container.Bind<GameObject[]>().FromInstance(tetrominos).NonLazy();
		Container.Bind<Vector3>().FromInstance(spawnPoint).NonLazy();
		Container.Bind<Spawner>().AsSingle().NonLazy();

		Container.Bind<TetrisBlock>().AsSingle().NonLazy();
    }
}